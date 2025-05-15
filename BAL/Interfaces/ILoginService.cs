namespace BAL.IService;

public interface ILoginService
{
    Task<bool> IsEmailPresentAsync(string email);
    Task<bool> IsManagerAsync(int id);
    Task<bool> IsPasswordCorrectAsync(string email, string password);
    Task<int> GetUserIdAsync(string email, string password);
    Task<string> GetAccNumberAsync(int id);
}
