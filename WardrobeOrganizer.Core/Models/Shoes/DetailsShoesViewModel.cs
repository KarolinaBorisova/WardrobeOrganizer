﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Core.Models.Shoes
{
    public class DetailsShoesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string Color { get; set; }

        public int SizeEu { get; set; }

        public int Centimetres { get; set; }

        public int? MemberId { get; set; }

        public string? MemberName { get; set; }

        public string Category { get; set; }

        public int StorageId { get; set; }

        public string? StorageName { get; set; }

        public string? HouseName { get; set; }

        public int HouseId { get; set; }

        public string UserId { get; set; }
    }
}
