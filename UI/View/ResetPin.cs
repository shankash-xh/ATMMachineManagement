using BAL.IService;
using BAL.Service;
using BAL.Validations;
namespace UI.View;

public class ResetPin
{
    private readonly IResetPinservice _resetService;
    private readonly AccountValidation _validation;
    public ResetPin()
    {
        _resetService = new ResetPinService();
        _validation = new();
    }
    public void ResetOtpPin()
    {
        Console.Clear();
        string accountNumber = "";
        string newPin = "";
        bool flag = true;
        while (flag)
        {
            Console.Write("Enter Your Account Number : ");
            accountNumber = Console.ReadLine()!;
            if (_validation.ValidateAccount(accountNumber.Trim()))
            {
                if (_resetService.IsAccountPressent(accountNumber).Result)
                {
                    _resetService.RendomOtpGenrator(accountNumber);
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Account Not Present !!!");
                }
            }
            else
            {
                Console.WriteLine("Account Number Should !0 digit Long");
            }
        }
        flag = true;
        while (flag)
        {
            Console.Write("Enter The Otp YOU Recived On the mail : ");
            string inputOtp = Console.ReadLine()!;
            if (_validation.ValidatedOtp(inputOtp.Trim()) && _resetService.IsInputOtpValid(inputOtp))
            {
                flag = false;
            }
            else
            {
                Console.WriteLine("Invalid Otp");
            }
        }
        flag = true;
        while (flag)
        {
            Console.Write("Enter the New Pin : ");
             newPin = Console.ReadLine()!;
            if (_validation.ValidatePin(newPin))
            {
                flag = false;
            }
        }

        flag = true;
        while (flag)
        {
            Console.Write("Enter the Confirm Pin : ");
             string confermPin = Console.ReadLine()!;
            if (confermPin==newPin && _validation.ValidatePin(newPin))
            {
                _resetService.ResetPinAsync(accountNumber, newPin);
                flag = false;
            }
        }
        
    }
}
