using AutoMapper;
using RPG.Dtos.Armors;
using RPG.Dtos.Characters;
using RPG.Dtos.Monsters;
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

            CreateMap<Character, GetCharacterWithArmorDto>();

            CreateMap<Armor, GetArmorDto>();
            CreateMap<AddArmorDto, Armor>();
            CreateMap<UpdateArmorDto, Armor>();
            
            CreateMap<Monster, GetMonsterDto>();
        }
    }
}