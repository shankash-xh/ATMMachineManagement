using DAL.Entity;

namespace DAL.IRepository;

public interface IRefillATMRepo
{
    Task<bool> RefillCash(ATMCashInventory inovatory);
    Task<ATMCashInventory?> GetInovatory(int id);

}
