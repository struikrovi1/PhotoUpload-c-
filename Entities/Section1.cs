using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Section1:BaseEntity
    {
        [Required(ErrorMessage = "Bos gonderme {0}-i")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Bos gonderme {0}-i")]
        public string Subheader { get; set; }
        public string? PhotoUrl { get; set; }
    }
}
