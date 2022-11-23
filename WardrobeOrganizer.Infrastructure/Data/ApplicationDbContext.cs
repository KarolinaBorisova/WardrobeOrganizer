using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WardrobeOrganizer.Infrastructure.Data.Configuration;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new StorageConfiguration());
            builder.ApplyConfiguration(new ClothingConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Storage> Storages { get; set; }

        public DbSet<Clothing> Clothes { get; set; }

        public DbSet<Shoes> Shoes { get; set; }

        public DbSet<Outerwear> Outerwear { get; set; }
    }
}