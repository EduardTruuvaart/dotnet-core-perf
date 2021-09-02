using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
public class StationService
{
  private readonly string apiKey;
  public StationService(string apiKey)
  {
    this.apiKey = apiKey;
  }

  public async Task<SearchResponse> Search(Location location)
  {
    HttpClient client = new HttpClient();
    string requestUri = $"https://api.zap-map.com/v5/chargepoints/locations/search?lat={location.Latitude}&long={location.Longitude}&radius=2&unit=KM&connector-types=&networks=&payments=&location-types=&access=2&ev-models=";
    System.Console.WriteLine(requestUri);
    var request = new HttpRequestMessage(HttpMethod.Get,
            requestUri);
    request.Headers.Add("X-Api-Key", this.apiKey);

    var response = await client.SendAsync(request);

    var responseStr = await response.Content.ReadAsStringAsync();

    using var responseStream = await response.Content.ReadAsStreamAsync();
    var data = await JsonSerializer.DeserializeAsync<SearchResponse>(responseStream);

    return data;
  }

  public async Task<DetailsResponse> GetDetails(int id)
  {
    HttpClient client = new HttpClient();
    string requestUri = $"https://api.zap-map.com/v5/chargepoints/locations/placecards?id={id}";
    System.Console.WriteLine(requestUri);
    var request = new HttpRequestMessage(HttpMethod.Get,
            requestUri);
    request.Headers.Add("X-Api-Key", this.apiKey);

    var response = await client.SendAsync(request);

    var responseStr = await response.Content.ReadAsStringAsync();

    using var responseStream = await response.Content.ReadAsStreamAsync();
    var data = await JsonSerializer.DeserializeAsync<DetailsResponse>(responseStream);

    return data;
  }

  public async Task<StatusResponse> GetStatus(int id)
  {
    HttpClient client = new HttpClient();
    string requestUri = $"https://api.zap-map.com/v5/chargepoints/location/{id}/status";
    System.Console.WriteLine(requestUri);
    var request = new HttpRequestMessage(HttpMethod.Get,
            requestUri);
    request.Headers.Add("X-Api-Key", this.apiKey);

    var response = await client.SendAsync(request);

    var responseStr = await response.Content.ReadAsStringAsync();

    using var responseStream = await response.Content.ReadAsStreamAsync();
    var data = await JsonSerializer.DeserializeAsync<StatusResponse>(responseStream);

    return data;
  }

  public async Task FetchStation(int id)
  {
    List<Task> tasks = new List<Task>();

    tasks.Add(this.GetDetails(id));
    tasks.Add(this.GetStatus(id));
    await Task.WhenAll(tasks);
  }
}