/*using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace KANOKO.Implemantation.Service
{
    public class CoinbasePaymentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiSecret;
        private const string ApiBaseUrl = "https://api.coinbase.com/v2/";

        public CoinbasePaymentService(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;
            _httpClient = new HttpClient();
        }


        public async Task<string> CreatePayment(decimal amount, string currency)
        {
            string requestPath = "/v2/payment";
            string httpMethod = "POST";
            string timestamp = GetUnixTimestamp().ToString();

            string body = JsonSerializer.Serialize(new
            {
                amount = amount.ToString(),
                currency = currency
            });

            string signature = GenerateSignature(httpMethod, requestPath, body, timestamp);

            _httpClient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", signature);
            _httpClient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", timestamp);

            var content = new StringContent(body, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(ApiBaseUrl + requestPath, content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var paymentResponse = JsonSerializer.Deserialize<PaymentResponse>(responseContent);

            return paymentResponse?.Id;
        }

        public async Task ProcessTransaction(string paymentId)
        {
            string requestPath = $"/v2/payment/{paymentId}/transaction";
            string httpMethod = "POST";
            string timestamp = GetUnixTimestamp().ToString();

            string signature = GenerateSignature(httpMethod, requestPath, null, timestamp);

            _httpClient.DefaultRequestHeaders.Remove("CB-ACCESS-SIGN");
            _httpClient.DefaultRequestHeaders.Remove("CB-ACCESS-TIMESTAMP");
            _httpClient.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", signature);
            _httpClient.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", timestamp);

            var response = await _httpClient.PostAsync(ApiBaseUrl + requestPath, null);

            response.EnsureSuccessStatusCode();

            
        }



        private long GetUnixTimestamp()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

        private string GenerateSignature(string method, string path, string body, string timestamp)
        {
            string message = timestamp + method + path + body;
            byte[] key = Encoding.UTF8.GetBytes(_apiSecret);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            using (var hmacsha256 = new HMACSHA256(key))
            {
                byte[] hashBytes = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToHexString(hashBytes).ToLower();
            }
        }
    

        public class PaymentResponse
        {
            public string Id { get; set; }
            public decimal Amount { get; set; }
            public string Currency { get; set; }
        }

        public class CoinbaseResponse
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public string CoinbasePaymentId { get; set; }
            public string AuthorizationUrl { get; set; }
        }
    }
}
*/