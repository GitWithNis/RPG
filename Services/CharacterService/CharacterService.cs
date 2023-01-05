using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core.GeoJson;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using RPG.Data;
using RPG.Dtos;
using RPG.Models;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        
        public CharacterService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ApiResponse<GetCharacterDto>> AddCharacter(AddCharacterDto request)
        {
            var response = new ApiResponse<GetCharacterDto>();
            var character = _mapper.Map<Character>(request);

            await _dataContext.Characters.AddAsync(character);
            await _dataContext.SaveChangesAsync();

            response.Data = _mapper.Map<GetCharacterDto>(character);
            return response;
        }

        public async Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ApiResponse<List<GetCharacterDto>>();
            response.Data = await _dataContext.Characters.Select(e => _mapper.Map<GetCharacterDto>(e)).ToListAsync();

            return response;
        }

        public async Task<ApiResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var response = new ApiResponse<GetCharacterDto>();
            var character = await _dataContext.Characters.FirstOrDefaultAsync(e => e.Id == Id);

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