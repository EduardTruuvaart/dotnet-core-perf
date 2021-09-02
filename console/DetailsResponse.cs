using System.Collections.Generic;

public class DetailsResponse
{
  public DetailsResources resources { get; set; }
}

public class DetailsResources
{
  public DetailsChargepointLocations chargepoint_locations_placecards { get; set; }
}

public class DetailsChargepointLocations
{
  public IList<StationDetails> data { get; set; }
}