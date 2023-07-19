﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Core.Models.Clothes
{
    public class ClothesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public string Description { get; set; }

        //public string Color { get; set; }

        public string Size { get; set; }

        public int? SizeHeight { get; set; }

        public int? MemberId { get; set; }

        // public  IEnumerable<MemberViewModel> Members{ get; set; }

        public string Category { get; set; }

        public int StorageId { get; set; }

        public string ImagePath { get; set; }
    }
}
