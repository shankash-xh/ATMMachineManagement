namespace BAL.IService;

public interface IResetPinservice
{

    Task<bool> ResetPinAsync(string accNumber, string newPin);
    Task<bool> IsAccountPressent(string accNumber);
    bool IsInputOtpValid(string inputOtp);
    Task<string> GetEmailAsync(int id);
    Task<int> GetUserIdAsync(string accNumber);
    string RendomOtpGenrator(string accNumber);
}
