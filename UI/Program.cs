using UI.View;

namespace UI;

public class Program
{
    static void Main()
    {
        bool flag = true;
        while (flag)
        {
            Console.Clear();
            Console.WriteLine("Choose One Option Below\n1  Login\n2  Reset Pin\n3  Quit");
            Console.Write("Enter Your Chooise : ");
            switch (Console.ReadLine())
            {
                case "1":
                    new Login().LoginDetails();
                    break;
                case "2":
                    new ResetPin().ResetOtpPin();
                    break;
                case "3":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
    }
}
