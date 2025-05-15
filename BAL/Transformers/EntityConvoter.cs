using Commen.Dtos;
using DAL.Entity;
namespace BAL.Transformers;

public static class EntityConvoter
{
    public static TransationDto EntityToDto(this ATMTransactions atmTransation)
    {
        return new TransationDto
        {
            AccountID = atmTransation.AccountID,
            Amount = atmTransation.Amount,
            Date = atmTransation.Date,
            Status = atmTransation.Status,
            TransactionType = atmTransation.TransactionType,
        };
    }
}
