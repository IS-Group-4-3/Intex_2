using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intex_2.Models.ViewModels
{
    public class MediaViewModel
    {
        public IEnumerable<FileRecord> files { get; set; }

        public PagingInfo PagingInfo { get; set; }
        public string CurrentType { get; set; }


    }
}
