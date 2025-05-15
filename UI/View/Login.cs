using BAL.IService;
using BAL.Service;
using BAL.Validations;
namespace UI.View;

public class Login
{
    private readonly ILoginService _loginService;
    private readonly UserValidation _userValidation;
    public Login()
    {
        _loginService = new LoginService();
        _userValidation = new ();
    }

    public void LoginDetails()
    {
        Console.Clear();
        string email="";
        string password="";
        bool flag = true;
        while (flag)
        {
            Console.Write("Enter your Login Email : ");
             email = Console.ReadLine()!;
            if (email != null)
            {
                if(_userValidation.ValidateEmail(email)) 
                    if( _loginService.IsEmailPresentAsync(email).Result)
                {
                    flag = false;
                    }
                    else
                    {
                        Console.WriteLine("*User Not Found*");
                    }
            }
            else
            {
                Console.WriteLine("*Email is Required*");
            }
        }
        flag = true;
        while (flag) 
        {
            Console.Write("Enter Your Password : ");
            password = Console.ReadLine()!;
            if (_userValidation.PasswordValidation(password))
            {
                if (_loginService.IsPasswordCorrectAsync(email!, password).Result)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Incorrect Password");
                }
            }
            else
            {
                Console.WriteLine("Invalid Password Password Must Be Between 4 and 20 Char ");
            }
        }
        int id = _loginService.GetUserIdAsync(email!,password).Result;
        bool isManager = _loginService.IsManagerAsync(id).Result;
       
        if (isManager)
        {
            new BankManagerMenu().ManagerMenu();
        }
        else
        {
            string accountNumber = _loginService.GetAccNumberAsync(id).Result;
            new UserMenu().UsersMenu(accountNumber);
        }
 
    }
}
