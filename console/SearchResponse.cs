using System.Collections.Generic;

public class SearchResponse
{
  public Resources resources { get; set; }
}

public class Resources
{
  public SearchChargepointLocations search_chargepoint_locations { get; set; }
}

public class SearchChargepointLocations
{
  public IList<Station> data { get; set; }
}