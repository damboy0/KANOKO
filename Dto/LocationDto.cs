namespace KANOKO.Dto
{
    public interface LocationDto
    {
        public string Address { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
    public interface LocationRequestModel
    {
        public string Address { get; set; }
    }
}
