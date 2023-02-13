using KANOKO.Identity;

namespace KANOKO.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<UserDto> Users { get; set; }
        public List<UserRole> UserRole { get; set; }
    }

    public class CreateRoleRequestModel
    {
        public string Name { get; set; }
    }
}
