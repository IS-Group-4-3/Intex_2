using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models.ViewModels
{
    public class UploadFileViewModel
    {
        [Required]
        public IFormFile photo { get; set; }

        [Required]
        public string type { get; set; }
        public int? LowPairNs { get; set; }
        public int? HighPairNs { get; set; }
        public string? BurialLocationNs { get; set; }
        public int? LowPairEw { get; set; }
        public int? HighPairEw { get; set; }
        public string? BurialLocationEw { get; set; }
        public string? BurialSubplot { get; set; }
        public int? BurialNumber { get; set; }

    }
}
