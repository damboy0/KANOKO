namespace KANOKO.Dto
{
    public class PayStackResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public PaystackData data { get; set; }
    }
    public class PaystackData
    {
        public string authorization_url { get; set; }
        public string access_code { get; set; }
        public string reference { get; set; }
    }
}
