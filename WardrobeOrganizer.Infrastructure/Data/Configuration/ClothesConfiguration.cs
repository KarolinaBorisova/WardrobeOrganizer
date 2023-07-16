using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Infrastructure.Data.Configuration
{
    internal class ClothesConfiguration : IEntityTypeConfiguration<Clothes>
    {
        public void Configure(EntityTypeBuilder<Clothes> builder)
        {
            builder.HasData(CreateClothing());
        }


        private List<Clothes> CreateClothing()
        {
            var clothes = new List<Clothes>();

            var clothing = new Clothes()
            {
                Id = 1,
                Name = "Тениска",
                Category = "Tshirt",
                Size = "М",
                StorageId = 1,
                ImgUrl = "http://unblast.com/wp-content/uploads/2019/04/Kids-T-Shirt-Mockup-1.jpg",
                ImagePath = "/images/1.jpg"

            };

            clothes.Add(clothing);

            return clothes;
        }
    }
}
