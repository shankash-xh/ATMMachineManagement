using DAL.DataBase;
using DAL.Entity;
using DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class CheckAccBalanceRepo : ICheckAccBalanceRepo
    {
        private readonly ATMMachineDbContext _dbcontext;
        public CheckAccBalanceRepo()
        {
            _dbcontext = new();
        }

        public async Task<Accounts?> CheckAccBalanceAsync(string accNumber) => await _dbcontext.Accounts.FirstOrDefaultAsync(account => account.AccountNumber == accNumber);


        public async Task<Accounts?> GetAccIdFromAccNumber(string accNumber) => await _dbcontext.Accounts.FirstOrDefaultAsync(account => account.AccountNumber == accNumber);

        public async Task<Accounts?> GetAccountPinAsync(string accountNumber) =>  await _dbcontext.Accounts.FirstOrDefaultAsync(account => account.AccountNumber == accountNumber);
    }
}
