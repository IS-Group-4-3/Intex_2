using System;
using System.Collections.Generic;

#nullable disable

namespace Intex_2.Models
{
    public partial class MainTblMdb
    {
        public int Gamous { get; set; }
        public string BurialId { get; set; }
        public string BurialLocationNs { get; set; }
        public string BurialLocationEw { get; set; }
        public int? LowPairNs { get; set; }
        public int? HighPairNs { get; set; }
        public int? LowPairEw { get; set; }
        public int? HighPairEw { get; set; }
        public string BurialSubplot { get; set; }
        public decimal BurialDepth { get; set; }
        public int SouthToHead { get; set; }
        public int SouthToFeet { get; set; }
        public int EastToHead { get; set; }
        public int EastToFeet { get; set; }
        public string BurialSituation { get; set; }
        public int? LengthOfRemains { get; set; }
        public int? BurialNumber { get; set; }
        public int? SampleNumber { get; set; }
        public string GenderGe { get; set; }
        public decimal? GeFunctionTotal { get; set; }
        public string GenderBodyCol { get; set; }
        public string BasilarSuture { get; set; }
        public int VentralArc { get; set; }
        public int SubpubicAngle { get; set; }
        public int SciaticNotch { get; set; }
        public int PubicBone { get; set; }
        public int PreaurSulcus { get; set; }
        public int MedialIpRamus { get; set; }
        public int DorsalPitting { get; set; }
        public string ForemanMagnum { get; set; }
        public decimal? FemurHead { get; set; }
        public decimal? HumerusHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PubicSymphysis { get; set; }
        public string BoneLength { get; set; }
        public string MedialClavicle { get; set; }
        public string IliacCrest { get; set; }
        public string FemurDiameter { get; set; }
        public string Humerus { get; set; }
        public decimal? FemurLength { get; set; }
        public decimal? HumerusLength { get; set; }
        public decimal? TibiaLength { get; set; }
        public int? Robust { get; set; }
        public int? SupraorbitalRidges { get; set; }
        public int? OrbitEdge { get; set; }
        public int? ParietalBossing { get; set; }
        public int? Gonian { get; set; }
        public int? NuchalCrest { get; set; }
        public int? ZygomaticCrest { get; set; }
        public string CranialSuture { get; set; }
        public decimal MaximumCranialLength { get; set; }
        public decimal MaximumCranialBreadth { get; set; }
        public decimal BasionBregmaHeight { get; set; }
        public decimal BasionNasion { get; set; }
        public decimal BasionProsthionLength { get; set; }
        public decimal BizygomaticDiameter { get; set; }
        public decimal NasionProsthion { get; set; }
        public decimal MaximumNasalBreadth { get; set; }
        public decimal InterorbitalBreadth { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColor { get; set; }
        public string PreservationIndex { get; set; }
        public string HairTaken { get; set; }
        public string SoftTissueTaken { get; set; }
        public string BoneTaken { get; set; }
        public string ToothTaken { get; set; }
        public string TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public string ArtifactFound { get; set; }
        public decimal? EstimateAge { get; set; }
        public decimal? EstimateLivingStature { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public int? YearFound { get; set; }
        public string MonthFound { get; set; }
        public int? DayFound { get; set; }
        public string HeadDirection { get; set; }
    }
}
