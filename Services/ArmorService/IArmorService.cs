using RPG.Dtos;
using RPG.Dtos.Armors;

namespace RPG.Services.ArmorService
{
    public interface IArmorService
    {
        public Task<ApiResponse<GetArmorDto>> AddArmor(AddArmorDto request);
        public Task<ApiResponse<GetArmorDto>> GetArmorById(int id);
        public Task<ApiResponse<List<GetArmorDto>>> GetAllArmor();
        public Task<ApiResponse<GetArmorDto>> UpdateArmor(UpdateArmorDto request);
        public Task<ApiResponse<List<GetArmorDto>>> DeleteArmor(int id);
    }
}