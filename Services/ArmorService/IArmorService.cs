using RPG.Dtos;
using RPG.Dtos.Armors;

namespace RPG.Services.ArmorService
{
    public interface IArmorService
    {
        public Task<ApiResponse<GetArmorDto>> AddArmor(AddArmorDto request);
        public Task<ApiResponse<GetArmorDto>> GetArmorById(FindArmorDto request);
        public Task<ApiResponse<List<GetArmorDto>>> GetAllArmor(int charId);
        public Task<ApiResponse<GetArmorDto>> UpdateArmor(UpdateArmorDto request);
        public Task<ApiResponse<List<GetArmorDto>>> DeleteArmor(DeleteArmorDto request);
    }
}