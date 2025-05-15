using Commen.Dtos;
using Commen.Enums;

namespace BAL.IService;

public interface IUserMenuService
{
    Task<decimal> CheckAccBalanceAsync(string accNumber);
    Task<int> GetDenominationCountAsync(int id);
    Task<bool> WithdrawAmountAsync(string accNumber, decimal withdrawAmount);
    Task<List<TransationDto>> GetTransationByAccNumberAsync(string AccountNumber);
    Task<string> GetAccountPinAsync(string accountNumber);
    Task<AccountTypeEnum> GetAccountTypeAsync(string accountNumber);
    Task<decimal> GetLimit();
}
