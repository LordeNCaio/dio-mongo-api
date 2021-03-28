namespace Api.Collections.Utils
{
    public class GeoJson2DGeographicCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeoJson2DGeographicCoordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}