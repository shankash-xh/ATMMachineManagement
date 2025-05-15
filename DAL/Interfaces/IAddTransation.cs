using DAL.Entity;

namespace DAL.IRepository;

public interface IAddTransation
{
    Task<ATMTransactions> AddTransationsAsync(ATMTransactions transaction);
}
