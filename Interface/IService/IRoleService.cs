using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IRoleService
    {
        Task<BaseResponse<RoleDto>> CreateRole(CreateRequestModel createRequestModel);
        Task<BaseResponse<RoleDto>> Get(int id);
        Task<BaseResponse<IEnumerable<RoleDto>>> GetAll();
    }
}
