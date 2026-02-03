using AutoMapper;
using GearVault.Models;
using GearVault.DTOs;
namespace GearVault.Mappings
{
    public class GearMappingProfile : Profile
    {
        public GearMappingProfile() 
        {
            CreateMap<GearItem, GearItemDto>();
            CreateMap<GearItem, GearDetailDto>();
            CreateMap<CreateItemDto, GearItem>();
            CreateMap<UpdateItemDto, GearItem>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
