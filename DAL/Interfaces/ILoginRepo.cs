using DAL.Entity;

namespace DAL.IRepository;

public interface ILoginRepo
{
    Task<bool> IsEmailPresentAsync(string email);
    Task<Users?> IsManagerAsync(int id);
    Task<bool> IsPasswordCorrectAsync(string email, string password);
    Task<Users?> GetUserIdAsync(string email, string password);
    Task<Accounts?> GetAccountNumber(int id);
}
