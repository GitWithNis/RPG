using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Characters;
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

        public async Task<ApiResponse<List<GetCharacterDto>>> DeleteCharacter(int Id)
        {
            var character = await _dataContext.Characters
                .FirstOrDefaultAsync(c => c.Id == Id);
            
            if (character is null)
                return new ApiResponse<List<GetCharacterDto>>(){
                    Success = false,
                    Message = $"Character with Id {Id} not found"
                };
                        
            _dataContext.Characters.Remove(character);
            await _dataContext.SaveChangesAsync();

            return await GetAllCharacters();
        }

        public async Task<ApiResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            return new ApiResponse<List<GetCharacterDto>>(){
                Data = await _dataContext.Characters.Select(e => _mapper.Map<GetCharacterDto>(e)).ToListAsync()
            };
        }

        public async Task<ApiResponse<GetCharacterDto>> GetCharacterById(int Id)
        {
            var character = await _dataContext.Characters
                .FirstOrDefaultAsync(e => e.Id == Id);

            if (character is null)
                return new ApiResponse<GetCharacterDto>(){
                    Success = false,
                    Message = $"Character with Id {Id} not found"
                };

            return new ApiResponse<GetCharacterDto>(){
                Data = _mapper.Map<GetCharacterDto>(character)
            };
        }

        public async Task<ApiResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateChar)
        {
            var character = await _dataContext.Characters
                .FirstOrDefaultAsync(e => e.Id == updateChar.Id);

            if (character is null)
                return new ApiResponse<GetCharacterDto>(){
                    Success = false,
                    Message = $"Character with Id {updateChar.Id} not found"
                };

            _mapper.Map(updateChar, character);
            await _dataContext.SaveChangesAsync();

            return await GetCharacterById(updateChar.Id);           
        }
    }
}