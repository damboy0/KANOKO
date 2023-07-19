using KANOKO.Dto;
using System.Transactions;

namespace KANOKO.Interface.IService
{
    public interface ITransactionService
    {
        public Task<TransactionResponseModel> CreateTransaction(CreateTransactionDto transaction);
        public Task<TransactionResponseModel> GetTransaction(int transactionId);
        public Task<TransactionsResponseModel> GetAllTransaction();
        public Task<TransactionResponseModel> GetTransactionByReferenceNumber(string referenceNumber);


    }
}
