using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Contracts
{
    public interface IStorageService
    {
        Task<ICollection<StoragesViewModel>> AllStorages();

    }
}
