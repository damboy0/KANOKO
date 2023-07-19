namespace KANOKO.Paystack
{
    public class GenerateRecipientData
    {
        public bool active { get; set; }
        public DateTime createdAt { get; set; }
        public string currency { get; set; }
        public string domain { get; set; }
        public int id { get; set; }
        public int integration { get; set; }
        public string name { get; set; }
        public string reference { get; set; }
        public string reason { get; set; }
        public string recipient_code { get; set; }
        public string type { get; set; }
        public VerifyBankData details { get; set; }
        
        ////TESTING
        // "data": {
        //     "active": true,
        //     "createdAt": "2020-05-13T13:59:07.741Z",
        //     "currency": "NGN",
        //     "domain": "test",
        //     "id": 6788170,
        //     "integration": 428626,
        //     "name": "John Doe",
        //     "recipient_code": "RCP_t0ya41mp35flk40",
        //     "type": "nuban",
        //     "updatedAt": "2020-05-13T13:59:07.741Z",
        //     "is_deleted": false,
        //     "details": {
        //         "authorization_code": null,
        //         "account_number": "0001234567",
        //         "account_name": null,
        //         "bank_code": "058",
        //         "bank_name": "Guaranty Trust Bank"
        //     }
    }
}
