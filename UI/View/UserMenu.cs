using UI.Funtionality;

namespace UI.View;

public class UserMenu
{
    public void UsersMenu(string accuntNumber)
    {
        bool flag = true;
        while (flag)
        {
            Console.Clear();
            Console.WriteLine("1  Check Balance\n2  Withdraw Money\n3  View Transactions\n4  Log out");
            string option = Console.ReadLine()!;
            switch (option)
            {
                case "1":
                    new UserMenuFunc().CheckBalance(accuntNumber);
                    Console.WriteLine("Press Enter To see Menu");
                    Console.ReadKey();
                    break;
                case "2":
                    new UserMenuFunc().WithdrawAmount(accuntNumber);
                    Console.WriteLine("Press Enter To see Menu");
                    Console.ReadKey();
                    break;
                case "3":
                    new UserMenuFunc().ViewTansations(accuntNumber);
                    Console.WriteLine("Press Enter To see Menu");
                    Console.ReadKey();
                    break;
                case "4":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("invalid Input");
                    break;
            }
        }
    }
}
