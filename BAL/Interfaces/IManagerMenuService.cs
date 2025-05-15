using Commen.Dtos;
using DAL.Entity;

namespace BAL.IService;

public interface IManagerMenuService
{
    Task<bool> RefillCash(int id, int count);
    Task<List<ATMCashInventory>> GetInovatoryInventoryAsync();
    Task<bool> ChangeMinWithDrawalLimit(decimal newlimit);
    Task<List<TransationDto>> GetAllTransactionsAsync();
    Task<decimal?> GetLimitAmountView();

}
