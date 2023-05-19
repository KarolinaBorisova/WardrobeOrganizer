using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IStorageService
    {
        Task<ICollection<AllStoragesViewModel>> AllStorages(int houseIs);

        Task<int> AddStorage(AddStorageViewModel storage, int houseId);
    }
}
