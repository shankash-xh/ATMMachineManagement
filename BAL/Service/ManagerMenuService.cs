using BAL.IService;
using BAL.Transformers;
using Commen.Dtos;
using Commen.Enums;
using DAL.Entity;
using DAL.IRepository;
using DAL.Repository;

namespace BAL.Service;

public class ManagerMenuService : IManagerMenuService
{
    private readonly IRefillATMRepo _refillAtm;
    private readonly IViewInovatoryRepo _viewInovatoryRepo;
    private readonly ISystemSetingRepo _systemSetingRepo;
    private readonly IViewTransationsRepo _viewTransationsRepo;
    private readonly IAddTransation _addTransationRepo;

    public ManagerMenuService()
    {
        _refillAtm = new RefillATMRepo();
        _viewInovatoryRepo = new ViewInovatoryRepo();
        _systemSetingRepo = new SystemSettingRepo();
        _viewInovatoryRepo = new ViewInovatoryRepo();
        _viewTransationsRepo = new ViewTransationsRepo();
        _addTransationRepo = new AddTransationRepo();
    }

    public async Task<bool> ChangeMinWithDrawalLimit(decimal newlimit)
    {
        var changeSettings = await _systemSetingRepo.GetLimitAmount();
        changeSettings.MinWithdrawLimit = newlimit;
        return await _systemSetingRepo.ChangeMinWithDrawalLimit(changeSettings);
    }

    public async Task<List<TransationDto>> GetAllTransactionsAsync()
    {
        var transations = await _viewTransationsRepo.GetAllTransactionsAsync();
        List<TransationDto> transationsDto = [];
        foreach (ATMTransactions transation in transations)
        {
            transationsDto.Add(transation.EntityToDto());
        }
        return transationsDto;
    }

    public async Task<List<ATMCashInventory>> GetInovatoryInventoryAsync()
    {
        return await _viewInovatoryRepo.GetInovatoryAsync();
    }

    public async Task<decimal?> GetLimitAmountView()
    {
        SystemSettings? limit =await _systemSetingRepo.GetLimitAmount();
        return limit?.MinWithdrawLimit;
    }

    public async Task<bool> RefillCash(int id, int count)
    {
        int[] amount = [100, 200, 500, 2000];
        int refilAmount = amount[id-1] * count;
        ATMTransactions transation = new()
        {
            AccountID = 2,
            Amount = refilAmount,
            Date = DateTime.Now,
            Status = StatusEnum.Success,
            TransactionType = TransactionTypeEnum.Refill,
        };
        await _addTransationRepo.AddTransationsAsync(transation);
        var changeInventory = await _refillAtm.GetInovatory(id);
        changeInventory.Count += count;
        return await _refillAtm.RefillCash(changeInventory);
    }
}
