using System;
using System.Collections.Generic;

#nullable disable

namespace Intex_2.Models
{
    public partial class GamousMain
    {
        public int? Gamous { get; set; }
        public string LocationId { get; set; }
        public string BurialSituationNotes { get; set; }
        public int? LengthOfRemains { get; set; }
        public int? SampleNumber { get; set; }
        public string GenderGe { get; set; }
        public decimal? GeFunctionTotal { get; set; }
        public string GenderBodyCol { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColor { get; set; }
        public string PreservationIndex { get; set; }
        public string ArtifactFound { get; set; }
        public decimal? EstimateAge { get; set; }
        public decimal? EstimateLivingStature { get; set; }
        public DateTime? DateFound { get; set; }
    }
}
