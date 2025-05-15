using BAL.IService;
using BAL.Service;
using Commen.Dtos;
using Commen.Enums;
namespace UI.Funtionality;

public class UserMenuFunc
{
    private IUserMenuService _userMenuService;
    public UserMenuFunc()
    {
        _userMenuService = new UserMenuService();
    }

    public void CheckBalance(string accountNumber)
    {
        decimal balance = _userMenuService.CheckAccBalanceAsync(accountNumber).Result;
        Console.WriteLine("Your Account Balance Is  : {0}/-", balance);
        Console.WriteLine();
    }

    public void WithdrawAmount(string accountNumber)
    {
        bool flag = true;
        ConfermAccountDetails(accountNumber);
        while (flag)
        {
            
            Console.Write("Enter The Amount You Want To Withdraw : ");
            string inputAmount = Console.ReadLine()!;
            if (inputAmount != null && decimal.TryParse(inputAmount, out decimal amount))
            {
                if (amount < 100)
                {
                    Console.WriteLine("Too Low Amount To Withdraw");
                }
                else if(amount > _userMenuService.CheckAccBalanceAsync(accountNumber).Result){
                    Console.WriteLine("You Don't Have Suffifent Balance");
                }else if (amount > _userMenuService.GetLimit().Result)
                {
                    Console.WriteLine("You Crrosed The Withdrow Limit the limit is {0} ",_userMenuService.GetLimit().Result);
                }
                else
                {
                    if (_userMenuService.WithdrawAmountAsync(accountNumber, amount).Result)
                    {
                        Console.WriteLine("Amount Withdrowen");
                        Console.WriteLine();
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("We only have 100 ,200, 500 , 2000 Notes");
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter a Valid Amount ");
            }
        }
    }

    public void ConfermAccountDetails(string accountNumber)
    {
        bool flag = true;
        while (flag) 
        {
            Console.Write("Enter Your accountNumber : ");
            string inputAmount = Console.ReadLine()!;
            if (accountNumber == inputAmount)
            {
                flag = false;
            }
            else
            {
                Console.WriteLine("Wrong Account Number ");
            }
        }
        flag = true;
        Console.WriteLine("1  Saving\n2  Current");
        while (flag) 
        {
            Console.Write("Enter Your Account Type : ");
            string input = Console.ReadLine()!;
            switch (input)
            {
                case "1":
                    if (ConfermAcountType(accountNumber, AccountTypeEnum.Saving))
                    {
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Account Type");
                    }
                    break;
                case "2":
                    if (ConfermAcountType(accountNumber, AccountTypeEnum.Current))
                    {
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Wrong Account Type");
                    }
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
        }
        flag = true;
        while (flag) 
        {
            Console.Write("Enter Your Account Pin : ");
            string inputPin = Console.ReadLine()!;
            if( inputPin == _userMenuService.GetAccountPinAsync(accountNumber).Result)
            {
                flag = false;
            }
            else
            {
                Console.WriteLine("Wrong Pin");
            }
        }
    }

    public bool ConfermAcountType(string accountNumber,AccountTypeEnum type)
    {
      if(type == _userMenuService.GetAccountTypeAsync(accountNumber).Result)
        {
            return true;
        }
        return false;
    }

    public void ViewTansations(string accNumber)
    {
        List<TransationDto>? Transations = _userMenuService.GetTransationByAccNumberAsync(accNumber).Result;
        if (Transations.Count <= 0) 
        {
            Console.WriteLine("No Transation Avalable To Show");
            return; 
        }


        foreach (TransationDto transation in Transations)
        {
            Console.WriteLine("Date : {0,-10} TransationType : {1,-10} Amount : {2,-10} Status : {3,-10}", transation.Date.ToString("dd-MMM-yyyy hh:mm tt"), transation.TransactionType.ToString(), transation.Amount, transation.Status.ToString());
        }
    }
}


