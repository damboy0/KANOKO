using KANOKO.Entity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace KANOKO.Dto
{
    public class TransactionDto
    {
        public string reference_id { get; set; }
        public TransactionStatus transaction_status { get; set; }
        public int AppUserId { get; set; }
        public string DriverId { get; set; }
        public decimal TotalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public int DeliveryDate { get; set; }
        public string ItemTitle { get; set; }
        public DateTime? CreatedDate { get; set; }
        //public int numberOfSub { get; set; }
    }

    public class CreateTransactionDto
    {
        public string Email { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverEmail { get; set; }
        public string DeliveryAddress { get; set; }
        public string ItemTitle { get; set; }
        public string PresentLocation { get; set; }
        public string ReceiverPhone { get; set; }
        public string DriverId { get; set; }
    }


        public class UpdateTransaction
        {
            public int CustomerId { get; set; }
            public string DriverId { get; set; }
        }

        public class TransactionResponseModel : BaseResponse
        {
            public TransactionDto Transaction { get; set; }
        }

        public class TransactionsResponseModel : BaseResponse
        {
            public IList<TransactionDto> TransactionList { get; set; }
        }
    }


