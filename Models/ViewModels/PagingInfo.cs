using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models.ViewModels
{
    public class PagingInfo
    {
        // the paginginfo model that makes pagination possible
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
