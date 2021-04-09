using System;
using System.Collections.Generic;

#nullable disable

namespace Intex_2.Models
{
    public partial class GamousLocation
    {
        public string LocationId { get; set; }
        public int? LowPairNs { get; set; }
        public int? HighPairNs { get; set; }
        public string BurialLocationNs { get; set; }
        public int? LowPairEw { get; set; }
        public int? HighPairEw { get; set; }
        public string BurialLocationEw { get; set; }
        public string BurialSubplot { get; set; }
        public int? BurialNumber { get; set; }
        public int? SouthToHead { get; set; }
        public int? SouthToFeet { get; set; }
        public int? EastToHead { get; set; }
        public int? EastToFeet { get; set; }
        public string HeadDirection { get; set; }
    }
}
