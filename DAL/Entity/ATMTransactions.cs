using Commen.Enums;

namespace DAL.Entity;

public class ATMTransactions
{
    public int Id { get; set; }
    public int AccountID { get; set; }
    public DateTime Date { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public decimal Amount { get; set; }
    public StatusEnum Status { get; set; }
    public string? Remarks { get; set; }
    public Accounts Accounts { get; set; } = null!;
}
