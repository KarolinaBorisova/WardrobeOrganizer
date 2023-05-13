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

        public async Task<int> AddStorage(AddStorageViewModel model, int familyId)
        {
            var storage = new Storage()
            {
                Name = model.Name,
                Place = model.Place,
                FamilyId = familyId,
            };

            await repo.AddAsync(storage);
            await repo.SaveChangesAsync();

            return storage.Id;
        }

        public async Task<ICollection<AllStoragesViewModel>> AllStorages(int familyId)
        {
            return await repo.AllReadonly<Storage>()
                .Where(s=>s.FamilyId == familyId )
                .OrderBy(x => x.Name)
               .Select(s => new AllStoragesViewModel
               {
                   Id = s.Id,
                   Name = s.Name,
                   Place = s.Place,

               }).ToListAsync();
        }
    }
}
