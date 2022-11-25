using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IStorageService
    {
        Task<IEnumerable<AllStoragesViewModel>> AllStorages();
    }
}
