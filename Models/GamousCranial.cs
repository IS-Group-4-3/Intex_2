using System;
using System.Collections.Generic;

#nullable disable

namespace Intex_2.Models
{
    public partial class GamousCranial
    {
        public string LocationId { get; set; }
        public int? SampleNumber { get; set; }
        public decimal? MaximumCranialLength { get; set; }
        public decimal? MaximumCranialBreadth { get; set; }
        public decimal? BasionbregmaHeight { get; set; }
        public decimal? Basionnasion { get; set; }
        public decimal? BasionprosthionLength { get; set; }
        public decimal? BizygomaticDiameter { get; set; }
        public decimal? Nasionprosthion { get; set; }
        public decimal? MaximumNasalBreadth { get; set; }
        public decimal? InterorbitalBreadth { get; set; }
        public string BurialPositioningNorthsouthNumber { get; set; }
        public string BurialPositioningNorthsouthDirection { get; set; }
        public string BurialPositioningEastwestNumber { get; set; }
        public string BurialPositioningEastwestDirection { get; set; }
        public int? BurialNumber { get; set; }
        public decimal? BurialDepth { get; set; }
        public string BurialSubplotDirection { get; set; }
        public string BurialArtifactDescription { get; set; }
        public string BuriedWithArtifacts { get; set; }
        public string Gilesgender { get; set; }
        public string Bodygender { get; set; }
    }
}
