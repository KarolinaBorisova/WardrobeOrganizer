using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Shoes
{
    public class ShoesViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        //public string Description { get; set; }

        public string ImgUrl { get; set; }

        //public string Color { get; set; }

        public int SizeEu { get; set; }

        public int Centimetres { get; set; }

        //public int? MemberId { get; set; }

        // public  IEnumerable<MemberViewModel> Members{ get; set; }

        public string Category { get; set; }

        public int StorageId { get; set; }
    }
}
