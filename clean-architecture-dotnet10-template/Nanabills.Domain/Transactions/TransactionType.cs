using Ardalis.SmartEnum;

namespace Nanabills.Domain.Transactions;

public class TransactionType : SmartEnum<TransactionType>
{
    public static readonly TransactionType Income = new(nameof(Income), 0);
    public static readonly TransactionType Expense = new(nameof(Expense), 1);

    public TransactionType(string name, int value) : base(name, value)
    {
    }
}
