namespace KANOKO.Contract
{
    public class AuditableEntity: BaseEntity, IAuditableEntity,ISoftDelete
    {
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
        public int LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public DateTime? IsDeleteOn { get; set; }
        public DateTime? IsDeleteBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
