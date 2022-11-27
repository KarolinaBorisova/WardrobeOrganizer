using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Services;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WardrobeOrganizerServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IMemberService, MemberService>();

            return services;
        }
    }
}
