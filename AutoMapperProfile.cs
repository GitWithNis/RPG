using AutoMapper;
using RPG.Dtos.Armors;
using RPG.Dtos.Characters;
using RPG.Dtos.Monsters;
using RPG.Dtos.Weapons;
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

            CreateMap<Character, GetCharacterWithDetailDto>();

            CreateMap<Armor, GetArmorDto>();
            CreateMap<AddArmorDto, Armor>();
            CreateMap<UpdateArmorDto, Armor>();

            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<CreateWeaponDto, Weapon>();

            CreateMap<Monster, GetMonsterDto>();
        }
    }
}