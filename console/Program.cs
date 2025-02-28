﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(
typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace dotnet_perf
{
  class Program
  {
    static async Task Main()
    {
      Console.WriteLine(AssemblyName.GetAssemblyName(@".\bin\Debug\netcoreapp3.1\dotnet-perf.dll"));

      Stopwatch sw = new Stopwatch();
      sw.Start();

      var apiKey = Environment.GetEnvironmentVariable("APIKEY");
      if (string.IsNullOrEmpty(apiKey)) {
        System.Console.WriteLine("ApiKey is missing!");
        return;
      }

      Location location = new Location(51.494698F, -0.153487F);
      StationService stationService = new StationService(apiKey);
      var searchResponse = await stationService.Search(location);
      var stations = searchResponse.resources.search_chargepoint_locations.data;

      List<Task> tasks = new List<Task>();
      foreach (var station in stations)
      {
        tasks.Add(stationService.FetchStation(station.id));
      }
      await Task.WhenAll(tasks);

      Console.WriteLine($"Statons Count: {searchResponse.resources.search_chargepoint_locations.data.Count}");

      TimeSpan ts = sw.Elapsed;
      string elapsedTime = String.Format("{0:00}.{1:00}",
            ts.Seconds,
            ts.Milliseconds);
      Console.WriteLine("Executon Time: " + elapsedTime);
    }
  }
}
