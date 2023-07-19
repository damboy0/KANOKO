using KANOKO.Entity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KANOKO.Dto
{
    public class TransactionTypeDto
    {
        public int TransactionId { get; set; }
        public string TransactionReferenceNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DriverId { get; set; }
        public decimal Price { get; set; }
        [EnumDataType(typeof(TransactionStatus))]
        [JsonConverter(typeof(StringEnumConverter))]
        public DateTime CreatedDate { get; set; }
        public string Reference { get; set; }
    }

    public class CreateTransactionTypeDto
    {
        public string Name { get; set; }
        public string TransactionReferenceNumber { get; set; }
        public string Description { get; set; }
        public int DeliveryDate { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateTransactionTypeDto
    {
        public int TransactionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPaidOut { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    public class TransactionTypeResponseModel : BaseResponse
    {
        public TransactionTypeDto Transaction { get; set; }
    }
    public class TransactionTypeListResponseModel : BaseResponse
    {
        public IList<TransactionTypeDto> Transaction { get; set; }
    }
}
