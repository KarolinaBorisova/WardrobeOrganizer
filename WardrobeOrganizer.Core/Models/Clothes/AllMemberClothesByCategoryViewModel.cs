﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Clothes
{
    public class AllMemberClothesByCategoryViewModel
    {
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string Category { get; set; }
        public IEnumerable<ClothesViewModel> Clothes { get; set; }
    }
}
