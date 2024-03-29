﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Outerwear:Item
    {
        public int? SizeHeight { get; set; }

        [Required]
        [MaxLength(5)]
        public string Size { get; set; } = null!;

    }
}
