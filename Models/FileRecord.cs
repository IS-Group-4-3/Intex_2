using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Intex_2.Models
{
    public partial class FileRecord
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }
        public string? LocationId { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
