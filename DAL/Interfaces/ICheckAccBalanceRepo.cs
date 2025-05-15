using DAL.Entity;

namespace DAL.IRepository;

public interface ICheckAccBalanceRepo
{
    Task<Accounts?> CheckAccBalanceAsync(string accountNumber);
    Task<Accounts?> GetAccIdFromAccNumber(string accountNumber);
    Task<Accounts?> GetAccountPinAsync(string accountNumber);
}
