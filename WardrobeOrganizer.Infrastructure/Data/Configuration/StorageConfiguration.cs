using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data.Configuration
{
    internal class StorageConfiguration : IEntityTypeConfiguration<Storage>
    {
        public void Configure(EntityTypeBuilder<Storage> builder)
        {
            builder.HasData(CreateStorage());
        }

        private List<Storage> CreateStorage()
        {
            var storages = new List<Storage>();

            var storage = new Storage()
            {
                Id = 1,
                Name = "Дестки гардероб",
                Place="В детската стая"
            };

            storages.Add(storage);

            return storages;
        }
    }
}
