using DAL.DataBase;
using DAL.Entity;
using DAL.IRepository;
using Commen.Enums;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class ViewTransationsRepo : IViewTransationsRepo
{
    private ATMMachineDbContext _dbcontext;
    public ViewTransationsRepo()
    {
        _dbcontext = new();
    }

    public async Task<List<ATMTransactions>> GetAllTransactionsAsync()
    {
        var allTansations = await _dbcontext.Transactions.AsQueryable().ToListAsync();
        return allTansations;
    }
    public async Task<Accounts?> GetAccountId(string accuntNumber)
    {
        Accounts? accountHolder = await _dbcontext.Accounts.FirstOrDefaultAsync(account => account.AccountNumber == accuntNumber);
        return accountHolder;
    }
    public async Task<List<ATMTransactions>> GetTransationByAccNumberAsync(int id)
    {
        //List<ATMTransactions>? Transations = await _dbcontext.Transactions.AsEnumerable().Where(transation => transation.AccountID == id && transation.TransactionType == TransactionTypeEnum.Withdraw).ToListAsync();

        List<ATMTransactions>? Transations = await _dbcontext.Transactions.Where(transation => transation.AccountID == id && transation.TransactionType == TransactionTypeEnum.Withdraw).ToListAsync();
        return Transations;
    }


}
