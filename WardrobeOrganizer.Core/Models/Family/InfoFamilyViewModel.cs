using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Core.Models.Storage;

namespace WardrobeOrganizer.Core.Models.Family
{
    public class InfoFamilyViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public ICollection<AllMembersViewModel> Members { get; set; } = null!;

        public ICollection<AllStoragesViewModel> Storages { get; set; } = null!;
    }
}
