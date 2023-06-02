using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WardrobeOrganizer.Infrastructure.Data.Configuration;

namespace WardrobeOrganizer.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new StorageConfiguration());
            builder.ApplyConfiguration(new ClothesConfiguration());
            builder.ApplyConfiguration(new FamilyConfiguration());
            builder.ApplyConfiguration(new HouseConfiguration());

            builder.Entity<Family>()
            .HasOne<User>(f=> f.User)
            .WithOne(u =>u.Family)
            .HasForeignKey<User>(u => u.FamilyId)
            .OnDelete(DeleteBehavior.SetNull);


            base.OnModelCreating(builder);
        }

        public DbSet<Storage> Storages { get; set; }

        public DbSet<Clothes> Clothes { get; set; }

        public DbSet<Shoes> Shoes { get; set; }

        public DbSet<Outerwear> Outerwear { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Family> Families { get; set; }

        public DbSet<House> Houses { get; set; }



    }
}