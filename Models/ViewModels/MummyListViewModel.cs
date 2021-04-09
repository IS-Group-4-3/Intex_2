using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models.ViewModels
{
    public class MummyListViewModel
    {
        public IEnumerable<GamousMain> mummies { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentLocationID { get; set; }

        public string CurrentHairColor { get; set; }

    }
}
