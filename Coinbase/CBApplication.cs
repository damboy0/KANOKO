using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Security.Cryptography;

namespace KANOKO
{
    class CBApplication
    {
        private const string API_URL = "https://api.coinbase.com";
        private const string SECRET = "b6650088-da89-4ca0-aa4d-db50fd49e8ec";
        private const string CB_ACCESS_KEY = "6bffc890-8380-4f60-897e-dc640a6a6dab";
        private static readonly string CB_ACCESS_TIMESTAMP = ((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds().ToString();

        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            const string requestPath = "/v2/accounts?limit=100";
            const string httpMethod = "GET";
            string cbAccessSign = "";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            byte[] keyByte = Encoding.ASCII.GetBytes(SECRET);//Convert.FromBase64String(SECRET);
            byte[] messageBytes = Encoding.ASCII.GetBytes(CB_ACCESS_TIMESTAMP + httpMethod + requestPath);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                cbAccessSign = Convert.ToHexString(hashmessage).ToLower();
            }

            client.DefaultRequestHeaders.Add("CB-ACCESS-KEY", CB_ACCESS_KEY);
            client.DefaultRequestHeaders.Add("CB-VERSION", "2015-07-22");
            client.DefaultRequestHeaders.Add("CB-ACCESS-SIGN", cbAccessSign);
            client.DefaultRequestHeaders.Add("CB-ACCESS-TIMESTAMP", CB_ACCESS_TIMESTAMP);

            var streamTask = client.GetStreamAsync(API_URL + requestPath);
            var account = await JsonSerializer.DeserializeAsync<CBAccount>(await streamTask);

            if (account != null && account.Data != null)
            {
                foreach (var data in account.Data)
                {
                    if (data.Balance != null)
                    {
                        Balance balance = data.Balance;

                        var amount = float.Parse(balance.Amount != null ? balance.Amount : "0.0");

                        if (amount > 0 && data.NativeBalance != null)
                        {
                            Console.WriteLine("{0}: {1:F12} (${2})", data.Currency, amount, data.NativeBalance.Amount);
                        }
                    }
                }
            }
        }
    }
}