using KANOKO.Identity;

namespace KANOKO.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoleRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class RoleResponseModel : BaseResponse
    {
        public RoleDto Data { get; set; }
    }
    public class RolesResponseModel : BaseResponse
    {
        public ICollection<RoleDto> Datas { get; set; } = new HashSet<RoleDto>();
    }
}
