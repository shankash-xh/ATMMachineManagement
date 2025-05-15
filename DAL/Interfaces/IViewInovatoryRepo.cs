using DAL.Entity;

namespace DAL.IRepository;

public interface IViewInovatoryRepo
{
    Task<List<ATMCashInventory>> GetInovatoryAsync();
}
