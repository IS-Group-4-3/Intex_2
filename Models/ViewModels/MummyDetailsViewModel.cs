using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models.ViewModels
{
    public class MummyDetailsViewModel
    {
        public GamousMain mummy { get; set; }
        public GamousLocation location { get; set; }
        public GamousDental dentalInfo { get; set; }
        public GamousCranial cranialInfo { get; set; }
        public GamousC14 carbonDating { get; set; }
        public GamousBone bone { get; set; }
        public GamousBiologicalSample bioSample { get; set; }
    }
}
