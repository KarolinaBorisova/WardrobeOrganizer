using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Accessories
{
    public class DetailsAccessoriesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public string Color { get; set; }

        public int SizeAge { get; set; }

        public int? MemberId { get; set; }

        public string? MemberName { get; set; }

        public string Category { get; set; }

        public int StorageId { get; set; }

        public string? StorageName { get; set; }

        public string? HouseName { get; set; }

        public int HouseId { get; set; }
    }
}
