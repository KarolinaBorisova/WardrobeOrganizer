﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        public int? StorageId { get; set; }

        [ForeignKey(nameof(StorageId))]
        public Storage? Storage { get; set; }

        public string? UserId { get; set; } 

        [Required]
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }


        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; } = null!;

        [Required]
        public int ShoeSizeEu { get; set; }


        public int? FootLengthCm { get; set; }

        [Required]
        [MaxLength(5)]
        public string ClothesSize { get; set; } = null!;

        public int? UserHeight { get; set; }

    }
}
