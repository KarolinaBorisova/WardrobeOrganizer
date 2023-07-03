using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeOrganizer.Infrastructure.Data.Configuration
{
    public class UsersWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {

            builder.HasData(CreateUserWithRoles());
        }

        private List<IdentityUserRole<string>> CreateUserWithRoles()
        {
            var roles = new List<IdentityUserRole<string>>();
          
            var role = new IdentityUserRole<string>
            {
                RoleId = "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                UserId = "0"

            };
          
            roles.Add(role);

            role = new IdentityUserRole<string>
            {
                RoleId = "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                UserId = "1"

            };

            roles.Add(role);

            role = new IdentityUserRole<string>
            {
                RoleId = "4070bb9e-78f6-4a73-b170-714f59bbc6e5",
                UserId = "2"

            };

            roles.Add(role);
            return roles;
        }
    }
    
}
