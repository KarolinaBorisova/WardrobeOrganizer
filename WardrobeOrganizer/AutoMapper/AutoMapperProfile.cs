using AutoMapper;
using WardrobeOrganizer.Core.Models.Accessories;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Core.Models.House;
using WardrobeOrganizer.Core.Models.Member;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
                CreateMap<Family,FamilyViewModel>().ReverseMap();
                CreateMap<House, AllHousesViewModel>().ReverseMap();
                CreateMap<House, InfoHouseViewModel>().ReverseMap();
                CreateMap<Member, AllMembersViewModel>().ReverseMap();
                CreateMap<Accessories, DetailsAccessoriesViewModel>().ReverseMap();
                CreateMap<Accessories, EditAccessoriesViewModel>().ReverseMap();
        }
    }
}
