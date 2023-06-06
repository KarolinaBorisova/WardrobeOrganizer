using Microsoft.EntityFrameworkCore;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WardrobeOriganizerApiServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Check what you need!

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IMemberService, MemberService>();
            services.AddScoped<IFamilyService, FamilyService>();
            services.AddScoped<IClothesService, ClothesService>();
            services.AddScoped<IHouseService, HouseService>();

            return services;
        }

        public static IServiceCollection AddWardrobeOrganizerDbContext(
            this IServiceCollection services,
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
