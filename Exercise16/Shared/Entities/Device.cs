using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise16.Shared.Entities
{
    public class Device
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("n");
        public string Name { get; set; } = string.Empty;
        public bool Online { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }

        
    }
}
