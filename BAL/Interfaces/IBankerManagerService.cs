using DAL.Entity;

namespace BAL.IService;

public interface IBankerManagerService
{
    Task<bool> RefillCash(int id, int count);
    Task<List<ATMCashInventory>> GetInovatoryInventoryAsync();
    Task<bool> ChangeMinWithDrawalLimit(decimal newlimit);
}
