using BAL.IService;
using BAL.Service;
using Commen.Dtos;
using DAL.Entity;
namespace UI.Funtionality;

public class ManagerMenuFunc
{
    private IManagerMenuService _managerMenuService;
    public ManagerMenuFunc()
    {
        _managerMenuService = new ManagerMenuService();
    }
    public void RefillAtm()
    {
        Console.Clear();
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("1  Add 100 Rs Note\n2  Add 200 Rs Note\n3  Add 500 Rs Note\n4  Add 2000 Rs Note\n5  do back");
            Console.Write("Choose your Option : ");
            string input = Console.ReadLine()!;
            switch (input)
            {
                case "1":
                    RefillMoney(1);
                    break;
                case "2":
                    RefillMoney(2);
                    break;
                case "3":
                    RefillMoney(3);
                    break;
                case "4":
                    RefillMoney(4);
                    break;
                case "5":
                    flag = false;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
    public void RefillMoney(int id)
    {
        bool flag = true;
        while (flag)
        {
            Console.Write("Enter The Note Count : ");
            string inputcount = Console.ReadLine()!;
            if (inputcount != null && int.TryParse(inputcount, out int count))
            {
                if (_managerMenuService.RefillCash(id, count).Result)
                {
                    Console.WriteLine("Cash Added !!!");
                    flag = false;
                }
            }
            else
            {
                Console.WriteLine("invalid input");
            }
        }
    }
    public void ViewInovatory()
    {
        List<ATMCashInventory>? Inovatory = _managerMenuService.GetInovatoryInventoryAsync().Result;
        foreach (ATMCashInventory inovatory in Inovatory)
        {
            Console.WriteLine("{0,-5}Rs  Count : {1,-5} ", inovatory.Denomination, inovatory.Count);
        }

    }
    public void ChangeMinwithdrow()
    {

        bool flag = true;
        while (flag)
        {
            decimal? oldLimit = _managerMenuService.GetLimitAmountView().Result;
            Console.Write("Enter The Min Amount To be Old Amount is {0} : ",oldLimit);
            string inputAmount = Console.ReadLine()!;
            if (inputAmount != null && decimal.TryParse(inputAmount, out decimal amount))
            {
                if (_managerMenuService.ChangeMinWithDrawalLimit(amount).Result)
                {
                    Console.WriteLine("Amount Changed");
                    flag = false;
                }
            }
            else
            {
                Console.WriteLine("Enter a valid input");
            }

        }
    }
    public void ViewAllTransations()
    {
        List<Commen.Dtos.TransationDto>? transations = _managerMenuService.GetAllTransactionsAsync().Result;
        if (transations.Count <= 0)
        {
            Console.WriteLine("No Transation To show");
            return;
        }
        foreach (TransationDto transation in transations)
        {
            Console.WriteLine("Date : {0,-10} TransationType : {1,-10} Amount : {2,-10} Status : {3,-10}", transation.Date.ToString("dd-MMM-yyyy hh:mm tt"), transation.TransactionType.ToString(), transation.Amount, transation.Status.ToString());
        }
    }
}
