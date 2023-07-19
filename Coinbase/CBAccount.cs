using System.Text.Json.Serialization;

namespace KANOKO
{
    public class Pagination
    {
        [JsonPropertyName("ending_before")]
        public string? EndingBefore { get; set; }

        [JsonPropertyName("starting_after")]
        public string? StartingAfter { get; set; }

        [JsonPropertyName("previous_ending_before")]
        public string? PreviousEndingBefore { get; set; }

        [JsonPropertyName("next_starting_after")]
        public string? NextStartingAfter { get; set; }

        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        [JsonPropertyName("order")]
        public string? Order { get; set; }

        [JsonPropertyName("previous_uri")]
        public string? PreviousUri { get; set; }

        [JsonPropertyName("next_uri")]
        public string? NextUri { get; set; }
    }

    public class Balance
    {
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

    }

    public class Data
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("primary")]
        public Boolean Primary { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("balance")]
        public Balance? Balance { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonPropertyName("resource")]
        public string? Resource { get; set; }

        [JsonPropertyName("resource_path")]
        public string? ResourcePath { get; set; }

        [JsonPropertyName("allow_deposits")]
        public Boolean AllowDeposits { get; set; }

        [JsonPropertyName("allow_withdrawals")]
        public Boolean AllowWithdrawals { get; set; }

        [JsonPropertyName("native_balance")]
        public Balance? NativeBalance { get; set; }
    }
         
    public class CBAccount
    {
        [JsonPropertyName("pagination")]
        public Pagination? Pagination { get; set; }

        [JsonPropertyName("data")]
        public List<Data>? Data { get; set; }
    }
}