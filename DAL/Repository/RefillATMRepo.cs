using DAL.DataBase;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;
namespace DAL.Repository;

public class RefillATMRepo : IRefillATMRepo
{
    private ATMMachineDbContext _dbcontext;
    public RefillATMRepo()
    {
        _dbcontext = new();
    }
    public async Task<ATMCashInventory?> GetInovatory(int id)
    {
        return await _dbcontext.Inventory.FirstOrDefaultAsync(inovatory => inovatory.Id == id);
    }
    public async Task<bool> RefillCash(ATMCashInventory inovatory)
    {
        _dbcontext.Inventory.Update(inovatory);
        await _dbcontext.SaveChangesAsync();
        return true;
    }
}
