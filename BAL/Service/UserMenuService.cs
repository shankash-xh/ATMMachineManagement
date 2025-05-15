using BAL.IService;
using BAL.Transformers;
using Commen.Dtos;
using DAL.IRepository;
using DAL.Repository;
using Commen.Enums;
using DAL.Entity;
using Microsoft.VisualBasic;
namespace BAL.Service;

public class UserMenuService : IUserMenuService
{
    private readonly ICheckAccBalanceRepo _checkAccBalanceRepo;
    private readonly IWithdrawAmountRepo _withdrawAmountRepo;
    private readonly IViewTransationsRepo _viewTransationsRepo;
    private readonly IViewInovatoryRepo _viewInovatoryRepo;
    private readonly IAddTransation _addTransationRepo;
    public UserMenuService()
    {
        _checkAccBalanceRepo = new CheckAccBalanceRepo();
        _withdrawAmountRepo = new WithdrawAmountRepo();
        _viewTransationsRepo = new ViewTransationsRepo();
        _viewInovatoryRepo = new ViewInovatoryRepo();
        _addTransationRepo = new AddTransationRepo();
    }
    public async Task<decimal> CheckAccBalanceAsync(string accNumber)
    {
        Accounts? account = await _checkAccBalanceRepo.CheckAccBalanceAsync(accNumber);
        return account == null ? 0 : account.Balance;
    }

    public async Task<int> GetDenominationCountAsync(int id)
    {
        ATMCashInventory? invantoryCount = await _withdrawAmountRepo.GetDenominationCountAsync(id);
        return invantoryCount == null ? 0 : invantoryCount.Count;
    }

    public async Task<decimal> GetLimit()
    {
        SystemSettings? limit = await _withdrawAmountRepo.LimitAmount();
        return limit == null ? 0 : limit.MinWithdrawLimit;
    }
    public async Task<bool> WithdrawAmountAsync(string accNumber, decimal withdrawAmount)
    {
        decimal amount = withdrawAmount;
        int[] noteCount = new int[4];
        int[] notes = { 100, 200, 500, 2000 };
        List<ATMCashInventory> inovatorys = await _viewInovatoryRepo.GetInovatoryAsync();
        int idexer = 0;
        foreach (ATMCashInventory innovatory in inovatorys)
        {
            noteCount[idexer] = innovatory.Count;
            idexer++;
        }

        while (amount > 0)
        {
            bool noteAvailable = false;

            for (int i = 3; i >= 0; i--)
            {
                if (amount >= notes[i] && noteCount[i] > 0)
                {
                    noteCount[i]--;
                    amount -= notes[i];
                    noteAvailable = true;
                    break;
                }
            }

            if (!noteAvailable)
            {
                return false;
            }
        }

        List<ATMCashInventory>? listOfCash = await _withdrawAmountRepo.GetListOfDenominationCountAsync();

        foreach (ATMCashInventory cash in listOfCash)
        {
            cash.Count = noteCount[cash.Id - 1];
        }

        await _withdrawAmountRepo.UpdateDenominationCountAsync(listOfCash);

        Accounts? account = await _checkAccBalanceRepo.GetAccIdFromAccNumber(accNumber);
        if (account == null)
            return false;

        TransationDto transationDto = new()
        {
            AccountID = account.Id,
            Date = DateTime.Now,
            Amount = withdrawAmount,
            TransactionType = TransactionTypeEnum.Withdraw,
            Status = StatusEnum.Success,
        };
       _ = await _addTransationRepo.AddTransationsAsync(transationDto.ToEntity());

        account.Balance -= withdrawAmount;
        await _withdrawAmountRepo.WithdrawAmountAsync(account);
        return true;
    }


    public async Task<List<TransationDto>> GetTransationByAccNumberAsync(string AccountNumber)
    {
        Accounts? account = await _viewTransationsRepo.GetAccountId(AccountNumber);
        List<ATMTransactions>? TransationsList = await _viewTransationsRepo.GetTransationByAccNumberAsync(account == null ? 0 : account.Id);
        List<TransationDto> transations = [];
        foreach (ATMTransactions transation in TransationsList)
        {
            transations.Add(transation.EntityToDto());
        }

        return transations;
    }

    public async Task<string> GetAccountPinAsync(string accountNumber)
    {
        Accounts? account = await _checkAccBalanceRepo.GetAccountPinAsync(accountNumber);
        return account?.Pin!;
    }
    public async Task<AccountTypeEnum> GetAccountTypeAsync(string accountNumber)
    {
        Accounts? account = await _checkAccBalanceRepo.GetAccountPinAsync(accountNumber);
        if (account == null) return default;
        return account.AccountType;
    }

}
