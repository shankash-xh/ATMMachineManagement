using DAL.Entity;

namespace DAL.IRepository;

public interface IResetPinRepo
{
    Task<bool> ResetPinAsync(Accounts account);
    Task<bool> IsAccountPressent(string accNumber);
    Task<Users?> GetEmailAsync(int id);
    Task<Accounts?> GetAccountId(string accuntNumber);
}
