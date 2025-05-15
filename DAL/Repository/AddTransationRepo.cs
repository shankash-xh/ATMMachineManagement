using DAL.DataBase;
using DAL.Entity;
using DAL.IRepository;

namespace DAL.Repository;

public class AddTransationRepo : IAddTransation
{
    private ATMMachineDbContext _dbcontext;
    public AddTransationRepo()
    {
        _dbcontext = new();
    }

    public async Task<ATMTransactions> AddTransationsAsync(ATMTransactions transaction)
    {
        var addResult = await _dbcontext.Transactions.AddAsync(transaction);
        await _dbcontext.SaveChangesAsync();
        return addResult.Entity;
    }
}
