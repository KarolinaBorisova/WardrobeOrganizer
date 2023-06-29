using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WardrobeOrganizer.Infrastructure.Data.Enums;

namespace WardrobeOrganizer.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUser());
        }

        private List<User> CreateUser()
        {
            var users = new List<User>();
            var hasher = new PasswordHasher<User>();

            var admin = new User
            {
                Id = "0",
                UserName = "admin@abv.bg",
                NormalizedUserName = "ADMIN@ABV.BG",
                FirstName = "Master",
                LastName = "Admin",
                Email = "admin@abv.bg",
                NormalizedEmail = "ADMIN@ABV.BG",

            };
            admin.PasswordHash = hasher.HashPassword(admin, "admin@abv.bg");
            users.Add(admin);

            var user = new User()
            {
                Id = "1",
                UserName = "dani@abv.bg",
                NormalizedUserName = "DANI@ABV.BG",
                Email = "dani@abv.bg",
                NormalizedEmail = "DANI@ABV.BG",
                FirstName = "Yordan",
                LastName = "Borisov"
            };

            user.PasswordHash = hasher.HashPassword(user, "dani@abv.bg");

            users.Add(user);

             user = new User()
            {
                Id = "2",
                UserName = "karolina@abv.bg",
                NormalizedUserName = "KAROLINA@ABV.BG",
                Email = "karolina@abv.bg",
                NormalizedEmail = "KAROLINA@ABV.BG",
                FirstName = "Karolina",
                LastName = "Borisova",
             };

            user.PasswordHash = hasher.HashPassword(user, "karolina@abv.bg");

            users.Add(user);

            return users;
        }
    }
}
