using Commen.Enums;

namespace Commen.Dtos;

public class TransationDto
{
    public int AccountID { get; set; }
    public DateTime Date { get; set; }
    public TransactionTypeEnum TransactionType { get; set; }
    public decimal Amount { get; set; }
    public StatusEnum Status { get; set; }
}
