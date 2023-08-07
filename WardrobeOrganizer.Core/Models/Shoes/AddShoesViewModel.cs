using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Core.Models.Shoes
{
    public class AddShoesViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IFormFile Image { get; set; }

        public string Color { get; set; }

        public int SizeEu { get; set; }

        public int Centimetres { get; set; }

        public int? MemberId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Members { get; set; } = new List<KeyValuePair<string, string>>();

        public string Category { get; set; }

        public int StorageId { get; set; }

        public string? UserId { get; set; }
    }
}
