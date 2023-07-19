using KANOKO.Contract;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace KANOKO.Entity
{
    public class Transaction: AuditableEntity
    {
        //public int Id { get; set; }
        AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public string? DriverId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ReceiverPhone { get; set; }
        public string PresentLocation { get; set; }
        public decimal TotalPrice { get; set; }
        public string ItemTitle { get; set; }
        public string ReferenceNumber { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
        [EnumDataType(typeof(TransactionStatus))]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }
        public IEnumerable<Payment> Payments { get; set; } = new List<Payment>();
        public IEnumerable<Dispute> Disputes { get; set; } = new List<Dispute>();
        public IList<AppUserTransaction> AppUserTransactions { get; set; } = new List<AppUserTransaction>();

    }
}
