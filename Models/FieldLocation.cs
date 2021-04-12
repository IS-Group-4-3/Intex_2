using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Intex_2.Models
{
    public partial class FieldLocation
    {
        [Key]
        public string LocationId { get; set; }
        public string BurialAreaNorthOrSouth { get; set; }
        public string Burialnors { get; set; }
        public int? BurialAreaEastOrWest { get; set; }
        public string Burialxeorw { get; set; }
        public string Square { get; set; }
        public string BurialNumber { get; set; }
        public string BurialWestToHead { get; set; }
        public string BurialWestToFeet { get; set; }
        public string BurialSouthToHead { get; set; }
        public string BurialSouthToFeet { get; set; }
        public string BurialDepth { get; set; }
        public string BurialDirection { get; set; }
    }
}
