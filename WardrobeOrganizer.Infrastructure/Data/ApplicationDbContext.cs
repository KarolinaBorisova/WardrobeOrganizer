using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Storage> Storages { get; set; }

        public DbSet<Clothing> Clothes { get; set; }

        public DbSet<Shoes> Shoes { get; set; }

        public DbSet<Outerwear> Outerwear { get; set; }
    }
}