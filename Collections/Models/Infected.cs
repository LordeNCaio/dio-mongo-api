using Api.Collections.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Collections.Models
{
    public class Infected
    {
        public DateTime BornDate { get; set; }
        public string Gender { get; set; }
        public GeoJson2DGeographicCoordinates GeoLocalization { get; set; }

        public Infected() { }
        public Infected(DateTime bornDate, string gender, double latitude, double longitude)
        {
            BornDate = bornDate;
            Gender = gender;
            GeoLocalization = new GeoJson2DGeographicCoordinates(latitude, longitude);
        }

    }
}
