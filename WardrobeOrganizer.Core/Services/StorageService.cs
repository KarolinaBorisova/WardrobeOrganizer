using Microsoft.EntityFrameworkCore;
using WardrobeOrganizer.Core.Contracts;
using WardrobeOrganizer.Core.Models.Storage;
using WardrobeOrganizer.Infrastructure.Data;
using WardrobeOrganizer.Infrastructure.Data.Common;

namespace WardrobeOrganizer.Core.Services
{
    public class StorageService : IStorageService
    {

        private readonly IRepository repo;

        public StorageService(IRepository _repo)
        {   
            repo = _repo;
        }

        public async Task<IEnumerable<AllStoragesViewModel>> AllStorages()
        {
            return await repo.AllReadonly<Storage>()
                .OrderBy(x => x.Name)
               .Select(s => new AllStoragesViewModel
               {
                   Id = s.Id,
                   Name = s.Name,

               }).ToListAsync();
        }
    }
}
