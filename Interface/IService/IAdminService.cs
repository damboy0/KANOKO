using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IAdminService
    {
        Task<BaseResponse<AdminDto>> Create(AdminRequestModel adminRequestModel);
        Task<BaseResponse<AdminDto>> Get(int id);
        Task<BaseResponse<IEnumerable<AdminDto>>> GetAll();
    }
}
