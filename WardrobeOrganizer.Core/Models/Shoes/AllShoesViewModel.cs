﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Outerwear;

namespace WardrobeOrganizer.Core.Models.Shoes
{
    public class AllShoesViewModel
    {
        public int StorageId { get; set; }
        public IEnumerable<ShoesViewModel> Shoes { get; set; }
    }
}