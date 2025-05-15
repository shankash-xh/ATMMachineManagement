using DAL.DataBase;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;
namespace DAL.Repository;

public class ResetPinRepo : IResetPinRepo
{
    private ATMMachineDbContext _dbcontext;
    public ResetPinRepo()
    {
        _dbcontext = new();
    }

    public async Task<Users?> GetEmailAsync(int id) => await _dbcontext.Users.FirstOrDefaultAsync(u => u.Id == id);
    public async Task<Accounts?> GetAccountId(string accNumber) => await _dbcontext.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accNumber);
    public async Task<bool> IsAccountPressent(string accNumber) => await _dbcontext.Accounts.AnyAsync(a => a.AccountNumber == accNumber);

    public async Task<bool> ResetPinAsync(Accounts account)
    {
       _dbcontext.Accounts.Update(account);
        await _dbcontext.SaveChangesAsync();
        return true;
    }
}
