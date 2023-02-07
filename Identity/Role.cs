namespace KANOKO.Identity
{
    public class Role
    {
        public string Name { get; set; }
        public List<UserRole> UserRoles { get; set; }= new List<UserRole>();
    }
}
