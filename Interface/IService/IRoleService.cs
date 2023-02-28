using KANOKO.Dto;
using System.Collections;

namespace KANOKO.Interface.IService
{
    public interface IRoleService
    {
        public Task<BaseResponse> CreateRole(RoleRequestModel model);
        public Task<BaseResponse> UpdateRole(RoleRequestModel model, int id);
        public Task<RolesResponseModel> GetRolesByUserId(int userId);
        public Task<RolesResponseModel> GetAllRoles();
    }
}
