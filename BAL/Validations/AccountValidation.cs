namespace BAL.Validations;

public class AccountValidation
{
    public bool ValidateAccount(string accNumber)
    {
        return accNumber.Length == 10;
    }
    public bool ValidatedOtp(string inputOtp)
    {
        return inputOtp.Length == 4;
    }
    public bool ValidatePin(string Pin)
    {
        if (Pin.Length != 4)
        {
            Console.WriteLine("invalid pin");
            return false;
        }
        if (int.TryParse(Pin, out int num))
        {
            return true;
        }
        Console.WriteLine("It Should Be Number only");
        return false;

    }
}
