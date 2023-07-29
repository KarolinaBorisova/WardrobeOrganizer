using AutoMapper;
using WardrobeOrganizer.Core.Models.Family;
using WardrobeOrganizer.Infrastructure.Data;

namespace WardrobeOrganizer.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
                CreateMap<Family,FamilyViewModel>();
        }
    }
}
