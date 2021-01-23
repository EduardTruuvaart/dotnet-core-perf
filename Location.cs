public class Location
{
  public float Latitude { get; }
  public float Longitude { get; }

  public Location(float latitude, float longitude)
  {
    this.Latitude = latitude;
    this.Longitude = longitude;
  }

  public override string ToString()
  {
    return $"Latitude: {this.Latitude} Longitude: {this.Longitude}";
  }
}