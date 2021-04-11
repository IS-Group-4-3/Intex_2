using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace Intex_2.Models
{
    public partial class FieldHairColor
    {
        [Key]
        public string Pk { get; set; }
        public string Text { get; set; }
    }
}
