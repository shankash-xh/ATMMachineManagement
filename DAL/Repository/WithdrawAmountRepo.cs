using DAL.DataBase;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;
namespace DAL.Repository;

public class WithdrawAmountRepo : IWithdrawAmountRepo
{
    private ATMMachineDbContext _dbcontext;
    public WithdrawAmountRepo()
    {
        _dbcontext = new();
    }

    public async Task<ATMCashInventory?> GetDenominationCountAsync(int id)
    {
        ATMCashInventory? invatory = await _dbcontext.Inventory.FirstOrDefaultAsync(invontorys => invontorys.Id == id);
        return invatory;
    }

    public async Task UpdateDenominationCountAsync(ATMCashInventory inovatory)
    {
        _dbcontext.Inventory.Update(inovatory);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task UpdateDenominationCountAsync(List<ATMCashInventory>? inovatory)
    {
        if (inovatory?.Count > 0)
        {
            _dbcontext.Inventory.UpdateRange(inovatory);
            await _dbcontext.SaveChangesAsync();
        }
    }

    public async Task<SystemSettings?> LimitAmount()
    {
        SystemSettings? limit = await _dbcontext.SystemSettings.FirstOrDefaultAsync(systemSetting => systemSetting.Id == 1);
        return limit;
    }

    public async Task<bool> WithdrawAmountAsync(Accounts account)
    {
        _dbcontext.Accounts.Update(account);
        await _dbcontext.SaveChangesAsync();
        return true;
    }

    public async Task<List<ATMCashInventory>> GetListOfDenominationCountAsync()
    {
        List<ATMCashInventory> inventory = await _dbcontext.Inventory.ToListAsync();
        return inventory;
    }
}
