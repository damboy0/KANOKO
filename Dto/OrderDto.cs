namespace KANOKO.Dto
{
    public class OrderDto
    {
        public int userId { get; set; }
        public string orderTransaction { get; set; }
        public string Description { get; set; }
    }
    public class OrderRequestModel
    {
        public int userId { get; set; }
        public string orderTransaction { get; set; }
        public string Description { get; set; }
    }
}
