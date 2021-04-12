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
    }
}
