using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IStorageService
    {
        Task<ICollection<AllStoragesViewModel>> AllStorages(int houseIs);

        Task<int> AddStorage(AddStorageViewModel storage);

        Task<InfoStorageViewModel> GetStorageById(int storageId);

        Task<bool> ExistsById(int id);

        Task Edit(InfoStorageViewModel model);

        Task Delete(int storageId);
    }
}
