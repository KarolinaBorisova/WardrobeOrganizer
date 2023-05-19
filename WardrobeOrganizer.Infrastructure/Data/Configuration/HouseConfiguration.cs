using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data.Configuration
{
    internal class HouseConfiguration : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.HasData(CreateHouse());
        }

        private List<House> CreateHouse()
        {
            var houses = new List<House>();

            var house = new House()
            {
                Id=1,
                FamilyId=1,
                Address = "Simeonsovkso shode 85",
                Name= "Home",
                Storages= new List<Storage>()

            };

            houses.Add(house);

            return houses;
        }
    }
}
