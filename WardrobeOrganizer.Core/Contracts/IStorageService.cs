using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IStorageService
    {
        Task<ICollection<StoragesViewModel>> AllStorages(int familyId);

        Task<int> AddStorage(AddStorageViewModel storage, int familyId);
    }
}
