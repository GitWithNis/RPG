using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RPG.Data;
using RPG.Dtos;
using RPG.Dtos.Armors;
using RPG.Models;

namespace RPG.Services.ArmorService
{
    public class ArmorService : IArmorService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public ArmorService(DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public async Task<ApiResponse<GetArmorDto>> AddArmor(AddArmorDto request)
        {
            var armor = _mapper.Map<Armor>(request);

            await _dataContext.AddAsync(armor);
            await _dataContext.SaveChangesAsync();

            return new ApiResponse<GetArmorDto>(){
                Data = _mapper.Map<GetArmorDto>(armor)
            };
        }

        public async Task<ApiResponse<List<GetArmorDto>>> DeleteArmor(int id)
        {
            var armor = await _dataContext.Armor
                .FirstOrDefaultAsync(a => a.Id == id);
            if (armor is null)
                return new ApiResponse<List<GetArmorDto>>(){
                    Success = false,
                    Message = $"Could not find Armor with Id {id}."
                };

            _dataContext.Remove(armor);
            await _dataContext.SaveChangesAsync();

            return await GetAllArmor();
        }

        public async Task<ApiResponse<List<GetArmorDto>>> GetAllArmor()
        {
            return new ApiResponse<List<GetArmorDto>>(){
                Data = await _dataContext.Armor
                    .Select(a => _mapper.Map<GetArmorDto>(a))
                    .ToListAsync()
            };
        }

        public async Task<ApiResponse<GetArmorDto>> GetArmorById(int id)
        {
            var armor = await _dataContext.Armor
                .FirstOrDefaultAsync(a => a.Id == id);
            if (armor is null)
                return new ApiResponse<GetArmorDto>(){
                    Success = false,
                    Message = $"Could not find Armor with Id {id}."
                };

            return new ApiResponse<GetArmorDto>(){
                Data = _mapper.Map<GetArmorDto>(armor)
            };
        }

        public async Task<ApiResponse<GetArmorDto>> UpdateArmor(UpdateArmorDto request)
        {
            var armor = await _dataContext.Armor
                .FirstOrDefaultAsync(a => a.Id == request.Id);
            if (armor is null)
                return new ApiResponse<GetArmorDto>(){
                    Success = false,
                    Message = $"Could not find Armor with Id {request.Id}."
                };

            _mapper.Map(request, armor);
            await _dataContext.SaveChangesAsync();
            
            return new ApiResponse<GetArmorDto>(){
                Data = _mapper.Map<GetArmorDto>(armor)
            };
        }
    }
}