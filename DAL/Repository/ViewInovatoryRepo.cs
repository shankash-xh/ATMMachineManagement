using DAL.DataBase;
using DAL.Entity;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class ViewInovatoryRepo : IViewInovatoryRepo
{
    private ATMMachineDbContext _dbcontext;
    public ViewInovatoryRepo()
    {
        _dbcontext = new();
    }

    public async Task<List<ATMCashInventory>> GetInovatoryAsync()
    {
        return await _dbcontext.Inventory.ToListAsync();
    }
}
