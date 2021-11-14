using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VGCatalogApp.Models
{
    public class VGSystem
    {
        [Key]
        public int Id { get; set; }
        public string Consoles { get; set;  }
        public string Title { get; set; }
    }

}
