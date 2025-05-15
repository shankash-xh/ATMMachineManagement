using Commen.Dtos;
using DAL.Entity;

namespace BAL.Transformers;

public static class DtoConvoter
{
    public static ATMTransactions ToEntity(this TransationDto transationDto)
    {
        return new ATMTransactions
        {
            AccountID = transationDto.AccountID,
            Date = transationDto.Date,
            TransactionType = transationDto.TransactionType,
            Amount = transationDto.Amount,
            Status = transationDto.Status
        };
    }
}
