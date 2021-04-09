using System;
using System.Collections.Generic;

#nullable disable

namespace Intex_2.Models
{
    public partial class BiologicalSample
    {
        public string RackNumber { get; set; }
        public string BagNumber { get; set; }
        public string LowPairNs { get; set; }
        public string HighPairNs { get; set; }
        public string BurialLocationNs { get; set; }
        public string LowPairEw { get; set; }
        public string HighPairEw { get; set; }
        public string BurialLocationEw { get; set; }
        public string BurialSubplot { get; set; }
        public string BurialNumber { get; set; }
        public int? ClusterNumber { get; set; }
        public string Date { get; set; }
        public string PreviouslySampled { get; set; }
        public string Notes { get; set; }
        public string Initials { get; set; }
    }
}
