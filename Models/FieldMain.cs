using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace Intex_2.Models
{
    public partial class FieldMain
    {
        public string YearOnSkull { get; set; }
        public string MonthOnSkull { get; set; }
        public int? DateOnSkull { get; set; }
        public string FieldBook { get; set; }
        public string FieldBookPageNumber { get; set; }
        public string InitialsOfDataEntryExpert { get; set; }
        public string InitialsOfDataEntryChecker { get; set; }
        public bool? ByuSample { get; set; }
        public int? BodyAnalysisYear { get; set; }
        public bool? SkullAtMagazine { get; set; }
        public bool? PostcraniaAtMagazine { get; set; }
        public string SexSkull2018 { get; set; }
        public string AgeSkull2018 { get; set; }
        public string Rack { get; set; }
        public int? Shelf { get; set; }
        public string RackAndShelf { get; set; }
        public bool? ToBeConfirmed { get; set; }
        public bool? SkullTrauma { get; set; }
        public bool? PostcraniaTrauma { get; set; }
        public bool? CribraOrbitala { get; set; }
        public bool? PoroticHyperostosis { get; set; }
        public string PoroticHyperostosisLocations { get; set; }
        public bool? MetopicSuture { get; set; }
        public bool? ButtonOsteoma { get; set; }
        public bool? PostcraniaTrauma1 { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public bool? TemporalMandibularJointOsteoarthritisTmjOa { get; set; }
        public bool? LinearHypoplasiaEnamel { get; set; }
        public int? AreaHillBurials { get; set; }
        public int? Tomb { get; set; }
        [Key]
        public string LocationId { get; set; }
        public string BurialDepth { get; set; }
        public string LengthOfRemains { get; set; }
        public int? YearExcavated { get; set; }
        public string MonthExcavated { get; set; }
        public int? DateExcavated { get; set; }
        public string BurialPreservation { get; set; }
        public string BurialWrapping { get; set; }
        public string BurialAdultChild { get; set; }
        public string GenderCode { get; set; }
        public string BurialGenderMethod { get; set; }
        public string AgeCode { get; set; }
        public string BurialAgeAtDeath { get; set; }
        public string BurialAgeMethod { get; set; }
        public string HairColorCode { get; set; }
        public string BurialHairColorText { get; set; }
        public string BurialSampleTaken { get; set; }
        public string LengthM { get; set; }
        public string Goods { get; set; }
        public string ClusterNum { get; set; }
        public bool? FaceBundle { get; set; }
        public string OsteologyNotes { get; set; }
        public string FieldNotes { get; set; }
    }
}
