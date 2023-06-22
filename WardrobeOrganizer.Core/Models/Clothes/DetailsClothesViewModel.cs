using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Clothes
{
    public class DetailsClothesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }

        public int? SizeHeight { get; set; }

         public int? MemberId { get; set; }

        public string? MemberName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Members { get; set; } = new List<KeyValuePair<string, string>>();

        public string Category { get; set; }

        public int StorageId { get; set; }

        public string? StorageName { get; set; }

        public string?  HouseName { get; set; }
    }
}
