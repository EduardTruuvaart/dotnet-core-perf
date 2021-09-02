using System.Collections.Generic;

public class StatusResponse
{
  public StatusResources resources { get; set; }
}

public class StatusResources
{
  public StatusChargepointLocations chargepoint_location_status { get; set; }
}

public class StatusChargepointLocations
{
  public StationStatus data { get; set; }
}