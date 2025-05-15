using DAL.Entity;

namespace DAL.IRepository;

public interface IWithdrawAmountRepo
{
    Task<ATMCashInventory?> GetDenominationCountAsync(int id);
    Task<List<ATMCashInventory>> GetListOfDenominationCountAsync();
    Task<bool> WithdrawAmountAsync(Accounts account);
    Task<SystemSettings?> LimitAmount();
    Task UpdateDenominationCountAsync(ATMCashInventory inovatory);
    Task UpdateDenominationCountAsync(List<ATMCashInventory> inovatories);
}
