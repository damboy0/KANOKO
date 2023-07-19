using KANOKO.Entity;

namespace KANOKO.Interface.IRepository
{
    public interface ITransactionRepository
    {
        public Task<Transaction> CreatTransaction(Transaction transaction);
        public Task<Transaction> GetTransaction(int transactionId);
        public Task<Transaction> UpdateTransaction(Transaction transaction);
        public Task<Transaction> DeleteTransaction(int transactionId);
        public Task<IList<Transaction>> GetAllTransaction();
        
        public Task<Transaction> GetTransactionByReferenceNumber(string referenceNumber);
        
    }
}
