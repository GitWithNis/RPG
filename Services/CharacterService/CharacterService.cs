using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Net.Http.Headers;
using RPG.Dtos;
using RPG.Models;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        //temp "data" object
        List<Character> charList = new List<Character>(){
            new Character(){Id = 1, Name = "FirstPerson"},
            new Character(){Id = 2, Name = "SecondPerson", MaxHP = 250, HP = 250}
        };
        private readonly IMapper _mapper;
        
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ApiResponse<List<GetCharacterDto>>();
            response.Data = charList.Select(e => _mapper.Map<GetCharacterDto>(e)).ToList();

            return response;
        }

        public async Task<ApiResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var response = new ApiResponse<GetCharacterDto>();
            var character = charList.FirstOrDefault(e => e.Id == Id);

            if (character is null){
                response.Success = false;
                response.Message = $"Could not find character with Id {Id}";
                return response;
            }

            response.Data = _mapper.Map<GetCharacterDto>(character);
            return response;
        }
    }
}