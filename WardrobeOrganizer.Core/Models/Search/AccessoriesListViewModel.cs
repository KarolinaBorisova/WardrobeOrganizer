using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.Core.Models.Search
{
    public class AccessoriesListViewModel
    {
        public IEnumerable<int> SizeByAges { get; set; }

        public IEnumerable<Item> Items { get; set; }

        public IEnumerable<string> Colors { get; set; }

        public string? Category { get; set; }
    }
}
