using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data.Configuration
{
    internal class ClothingConfiguration : IEntityTypeConfiguration<Clothing>
    {
        public void Configure(EntityTypeBuilder<Clothing> builder)
        {
            builder.HasData(CreateClothing());
        }


        private List<Clothing> CreateClothing()
        {
            var clothes = new List<Clothing>();

            var clothing = new Clothing()
            {
                Id = 1,
                Name = "Тениска",
                CategoryClothing = CategoryClothing.Tshirt,
                Size = "М",
                StorageId = 1,
                Url = "http://unblast.com/wp-content/uploads/2019/04/Kids-T-Shirt-Mockup-1.jpg"

            };

            clothes.Add(clothing);

            return clothes;
        }
    }
}
