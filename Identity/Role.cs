namespace KANOKO.Identity
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserRole> UserRoles { get; set; }= new List<UserRole>();
    }
}
