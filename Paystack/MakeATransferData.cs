namespace KANOKO.Paystack
{
    public class MakeATransferData
    {
        public string reference { get; set; }
        public int integration { get; set; }
        public string domain { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
        public string source { get; set; }
        public string reason { get; set; }
        public int recipient { get; set; }
        public string status { get; set; }
        public string transfer_code { get; set; }
        public int id { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
    }
}
