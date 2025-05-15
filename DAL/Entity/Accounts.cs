using Commen.Enums;

namespace DAL.Entity;

public class Accounts
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public required string AccountNumber { get; set; }
    public required string Pin { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public  AccountTypeEnum AccountType { get; set; }
    public  decimal Balance { get; set; } = 0;

    public Users User { get; set; } = null!;
    public ICollection<ATMTransactions>? Transactions { get; set; }
}
