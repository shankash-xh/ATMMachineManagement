using DAL.DataBase;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;
namespace DAL.Repository;

public class LoginRepo : ILoginRepo
{
    private ATMMachineDbContext _dbcontext;
    public LoginRepo()
    {
        _dbcontext = new();
    }

    public async Task<Accounts?> GetAccountNumber(int id) => await _dbcontext.Accounts.FirstOrDefaultAsync(account => account.UserId == id);

    public async Task<Users?> GetUserIdAsync(string email, string password) => await _dbcontext.Users.FirstOrDefaultAsync(users => users.Email == email && users.Password == password);

    public async Task<bool> IsEmailPresentAsync(string email) => await _dbcontext.Users.AnyAsync(users => users.Email == email);

    public async Task<Users?> IsManagerAsync(int id) => await _dbcontext.Users.FirstOrDefaultAsync(users => users.Id == id);

    public async Task<bool> IsPasswordCorrectAsync(string email, string password) => await _dbcontext.Users.AnyAsync(users => users.Email == email && users.Password == password);
}
