using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data.Configuration
{
    internal class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(CreateRoles());
        }


        private List<IdentityRole> CreateRoles()
        {
            var roles = new List<IdentityRole>();

            var role = new IdentityRole()
            {
                Id = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                Name = "Administrator",
                NormalizedName = "Administrator"

            };

            roles.Add(role);

           role = new IdentityRole()
            {
                Id = "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                Name = "User",
                NormalizedName = "USER"

            };

            roles.Add(role);

            return roles;
        }
    }
}
