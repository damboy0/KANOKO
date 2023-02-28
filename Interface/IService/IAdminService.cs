using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface IAdminService
    {
        public Task<BaseResponse> RegisterAdmin(AdminRequestModel model);
        public Task<BaseResponse> UpdateAdmin(UpdateAdminRequestModel model, int id);
        public Task<AdminResponseModel> GetAdmin(int id);
        public Task<AdminResponseModel> GetAdminByEmail(string email);
        public Task<AdminsResponseModel> GetAllAdmins();
        public Task<BaseResponse> ActivateAdmin(int id);
        public Task<BaseResponse> DeActivateAdmin(int id);
        public Task<AdminsResponseModel> GetAllActiveAdmins();
        public Task<AdminsResponseModel> GetAllDeactivatedAdmins();
    }
}
