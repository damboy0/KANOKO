using KANOKO.Context;
using KANOKO.Entity;
using KANOKO.Identity;
using KANOKO.Interface.IRepository;
using Microsoft.EntityFrameworkCore;


namespace KANOKO.Implemantation.Repository
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly ApplicationContext _context;

        public TransactionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Transaction> CreatTransaction(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> GetTransaction(int transactionId)
        {
            return await _context.Transactions.SingleOrDefaultAsync(s => s.Id == transactionId);
        }

        public async Task<Transaction> UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> DeleteTransaction(int transactionId)
        {
            var transaction = await _context.Transactions.SingleOrDefaultAsync(s => s.Id == transactionId);
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<IList<Transaction>> GetAllTransaction()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> GetTransactionByReferenceNumber(string referenceNumber)
        {
            return await _context.Transactions.FirstOrDefaultAsync(t => t.ReferenceNumber == referenceNumber);
        }
    }
}
