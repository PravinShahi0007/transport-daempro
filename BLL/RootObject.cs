using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    [Serializable]
    public class RootObject
    {
        public List<Route> routes { get; set; }
        public string status { get; set; }
    }

    //------------------------------------------- Google Map------------------------
    [Serializable]
    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    [Serializable]
    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    [Serializable]
    public class Bounds
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    [Serializable]
    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    [Serializable]
    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    [Serializable]
    public class EndLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    [Serializable]
    public class StartLocation
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    [Serializable]
    public class Distance2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    [Serializable]
    public class Duration2
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    [Serializable]
    public class EndLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    [Serializable]
    public class Polyline
    {
        public string points { get; set; }
    }

    [Serializable]
    public class StartLocation2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    [Serializable]
    public class Step
    {
        public Distance2 distance { get; set; }
        public Duration2 duration { get; set; }
        public EndLocation2 end_location { get; set; }
        public string html_instructions { get; set; }
        public Polyline polyline { get; set; }
        public StartLocation2 start_location { get; set; }
        public string travel_mode { get; set; }
        public string maneuver { get; set; }
    }

    [Serializable]
    public class Leg
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string end_address { get; set; }
        public EndLocation end_location { get; set; }
        public string start_address { get; set; }
        public StartLocation start_location { get; set; }
        public List<Step> steps { get; set; }
        public List<object> via_waypoint { get; set; }
    }

    [Serializable]
    public class OverviewPolyline
    {
        public string points { get; set; }
    }

    [Serializable]
    public class Route
    {
        public Bounds bounds { get; set; }
        public string copyrights { get; set; }
        public List<Leg> legs { get; set; }
        public OverviewPolyline overview_polyline { get; set; }
        public string summary { get; set; }
        public List<object> warnings { get; set; }
        public List<object> waypoint_order { get; set; }
    }

}
