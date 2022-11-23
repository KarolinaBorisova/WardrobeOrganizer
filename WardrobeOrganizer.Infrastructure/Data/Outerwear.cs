﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Outerwear:Item
    {
        public int? SizeHeight { get; set; }

        [MaxLength(5)]
        public string Size { get; set; }

        [Required]
        public CategoryOuterwear CategoryOuterwear { get; set; }

        public int StorageId { get; set; }

        [Required]
        [ForeignKey(nameof(StorageId))]
        public Storage Storage { get; set; }
    }
}
