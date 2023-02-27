using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise16.Shared.Entities
{
    public class CreateDevice
    {
        [Required]
        [StringLength(10, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
    }
}
