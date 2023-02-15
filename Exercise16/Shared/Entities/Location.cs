using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise16.Shared.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Address { get; set; } = string.Empty;
        public string CityTown { get; set; } = string.Empty;
        public string StateProvince { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
