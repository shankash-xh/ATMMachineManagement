using BAL.IService;
using DAL.Entity;
using DAL.IRepository;
using DAL.Repository;
namespace BAL.Service;

public class LoginService : ILoginService
{
    private readonly ILoginRepo _loginRepo;
    public LoginService()
    {
        _loginRepo = new LoginRepo();
    }

    public async Task<string> GetAccNumberAsync(int id)
    {
        Accounts? account = await _loginRepo.GetAccountNumber(id);
        return account?.AccountNumber!;
    }

    public async Task<int> GetUserIdAsync(string email, string password) 
    {
        Users? user = await _loginRepo.GetUserIdAsync(email, password);
        return user==null?0:user.Id;
    }

    public async Task<bool> IsEmailPresentAsync(string email) => await _loginRepo.IsEmailPresentAsync(email);

    public async Task<bool> IsManagerAsync(int id) 
    { Users? user = await _loginRepo.IsManagerAsync(id); 
        return user!=null && user.IsManager;
    }

    public async Task<bool> IsPasswordCorrectAsync(string email, string password) => await _loginRepo.IsPasswordCorrectAsync(email, password);

}
