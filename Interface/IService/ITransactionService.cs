using KANOKO.Dto;

namespace KANOKO.Interface.IService
{
    public interface ITransactionService
    {
        public Task<TransactionRequestModel> CreateTransactionAsync(int userId);
    }
}
