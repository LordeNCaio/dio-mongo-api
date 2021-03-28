using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class InfectedDTO
    {
        public DateTime BornDate { get; set; }
        public string Gender { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
