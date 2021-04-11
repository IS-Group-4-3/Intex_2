using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace Intex_2.Models
{
    public partial class GamousC14
    {
        [Key]
        public string LoctionId { get; set; }
        public int? Rack { get; set; }
        public int? Ns { get; set; }
        public string LocationNs { get; set; }
        public int? Ew { get; set; }
        public string LocationEw { get; set; }
        public string Square { get; set; }
        public int? Area { get; set; }
        public int? Burial { get; set; }
        public int? Tube { get; set; }
        public string Description { get; set; }
        public int? SizeMl { get; set; }
        public int? Foci { get; set; }
        public int? C14Sample2017 { get; set; }
        public string Location { get; set; }
        public string Questions { get; set; }
        public int? SomeNumber { get; set; }
        public int? Conventional14cAgeBp { get; set; }
        public int? C14CalendarDate { get; set; }
        public int? Calibrated95CalendarDateMax { get; set; }
        public int? Calibrated95CalendarDateMin { get; set; }
        public int? Calibrated95CalendarDateSpan { get; set; }
        public string Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }
    }
}
