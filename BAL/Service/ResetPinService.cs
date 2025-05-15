using BAL.IService;
using DAL.IRepository;
using DAL.Repository;
using Utility.EmailSender;
using DAL.Entity;
namespace BAL.Service;

public class ResetPinService : IResetPinservice
{
    private static string _rendomOtp = "";
    private readonly IResetPinRepo _resetOtpRepo;
    public ResetPinService()
    {
        _resetOtpRepo = new ResetPinRepo();
    }

    public async Task<bool> IsAccountPressent(string accNumber) => await _resetOtpRepo.IsAccountPressent(accNumber);

    public async Task<bool> ResetPinAsync(string accNumber, string newPin)
    {
        var account = await _resetOtpRepo.GetAccountId(accNumber);
           account.Pin = newPin;
        return await _resetOtpRepo.ResetPinAsync(account);
    }
    public string RendomOtpGenrator(string accNumber)
    {
        string email = GetEmailAsync(GetUserIdAsync(accNumber).Result).Result;
        Random random = new();
        _rendomOtp = "" + random.Next(1000, 10000);
        SendEmail.SendOtp(_rendomOtp, email);
        return _rendomOtp;
    }

    public async Task<string> GetEmailAsync(int id)
    {
        Users? user = await _resetOtpRepo.GetEmailAsync(id);
        return user?.Email!;
    }

    public async Task<int> GetUserIdAsync(string accNumber)
    {
        Accounts? account = await _resetOtpRepo.GetAccountId(accNumber);
        return account == null ? 0 : account.UserId;
    }

    public bool IsInputOtpValid(string inputOtp)
    {
        return inputOtp == _rendomOtp;
    }
}
