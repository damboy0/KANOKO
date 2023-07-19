using KANOKO.Entity;

namespace KANOKO.Dto
{
    public class LocationDto
    {
        public int Id { get; set; } 
        public decimal Price { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public LocationStatus Status { get; set; }
    }

    public class CreateLocationRequestModel
    {
        public decimal Price { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

    public class UpdateLocationRequestModel
    {
        
        public decimal Price { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public LocationStatus Status { get; set; }
    }

    public class LocationResponseModel : BaseResponse
    {
        public LocationDto Location { get; set; }
    }




}
