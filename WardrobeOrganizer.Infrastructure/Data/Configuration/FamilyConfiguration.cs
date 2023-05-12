using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Infrastructure.Data.Configuration
{
    public class FamilyConfiguration : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.HasData(CreateFamily());
        }

        private List<Family> CreateFamily()
        {
            var families = new List<Family>();

            var family = new Family()
            {
               Id = 1,
               Name = "Borisovi",
               UserId = "1"

            };

            families.Add(family);

            family = new Family()
            {
                Id = 2,
                Name = "Popovi",
                UserId = "2"

            };

            families.Add(family);

            return families;
        }
    }
}
