using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IStorageService
    {
        Task<ICollection<AllStoragesViewModel>> AllStorages(int familyId);

        Task<int> AddStorage(AddStorageViewModel storage, int familyId);
    }
}
