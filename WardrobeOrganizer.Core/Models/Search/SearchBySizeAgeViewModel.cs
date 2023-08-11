using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Search
{
    public class SearchBySizeAgeViewModel
    {
        public IEnumerable<int> SizeByAges { get; set; }

        public string Category { get; set; }

    }
}
    