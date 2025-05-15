using DAL.DataBase;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using DAL.Entity;
namespace DAL.Repository;

public class SystemSettingRepo : ISystemSetingRepo
{
    private ATMMachineDbContext _dbcontext;
    public SystemSettingRepo()
    {
        _dbcontext = new();
    }


    public async Task<bool> ChangeMinWithDrawalLimit(SystemSettings systemSetings)
    {
        _dbcontext.SystemSettings.Update(systemSetings);
        await _dbcontext.SaveChangesAsync();
        return true;
    }

    public async Task<SystemSettings?> GetLimitAmount()=> await _dbcontext.SystemSettings.FirstOrDefaultAsync(systemLimit => systemLimit.Id == 1);
}
