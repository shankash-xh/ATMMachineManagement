using DAL.Entity;

namespace DAL.IRepository;

public interface IViewTransationsRepo
{
    Task<List<ATMTransactions>> GetTransationByAccNumberAsync(int id);
    Task<List<ATMTransactions>> GetAllTransactionsAsync();
    Task<Accounts?> GetAccountId(string accuntNumber);
}
