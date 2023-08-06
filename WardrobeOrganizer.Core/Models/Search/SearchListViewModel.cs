using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Search
{
    public class SearchListViewModel
    {
        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<string> ClothesSizes { get; set; }

        public IEnumerable<int> ShoeSizesEu { get; set; }

        public IEnumerable<int> SizeByAges { get; set; }

        public IEnumerable<string> Colors { get; set; }
    }
}
