using AutoMapper;
using RPG.Dtos.Armors;
using RPG.Dtos.Characters;
using RPG.Models;

namespace RPG
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();

            CreateMap<Armor, GetArmorDto>();
            CreateMap<AddArmorDto, Armor>();
            CreateMap<UpdateArmorDto, Armor>();
        }
    }
}