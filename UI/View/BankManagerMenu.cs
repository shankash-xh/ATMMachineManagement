using UI.Funtionality;

namespace UI.View;

public class BankManagerMenu
{
    public void ManagerMenu()
    {
        bool flag = true;
        while (flag)
        {
            Console.Clear();
            Console.WriteLine("1  Refill ATM\n2  View ATM Cash Inventory\n3  Change Min Withdrawal Limit\r\n4  View All Transactions\r\n5  Logout");
            Console.WriteLine("Choose Your Option");
            string option = Console.ReadLine()!;
            switch (option)
            {
                case "1":
                    new ManagerMenuFunc().RefillAtm();
                    break;
                case "2":
                    new ManagerMenuFunc().ViewInovatory();
                    Console.WriteLine("Press Enter To see Menu");
                    Console.ReadKey();
                    break;
                case "3":
                    new ManagerMenuFunc().ChangeMinwithdrow();
                    Console.WriteLine("Press Enter To see Menu");
                    Console.ReadKey();
                    break;
                case "4":
                    new ManagerMenuFunc().ViewAllTransations();
                    Console.WriteLine("Press Enter To see Menu");
                    Console.ReadKey();
                    break;
                case "5":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("invalid Input");
                    break;
            }
        }
    }
}
