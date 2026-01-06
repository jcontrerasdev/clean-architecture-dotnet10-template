using Ardalis.SmartEnum;

namespace Nanabills.Domain.Transactions;

public class TransactionStatusType : SmartEnum<TransactionStatusType>
{
    public static readonly TransactionStatusType Pending = new(nameof(Pending), 0);
    public static readonly TransactionStatusType Completed = new(nameof(Completed), 1);
    public static readonly TransactionStatusType Failed = new(nameof(Failed), 2);
    public static readonly TransactionStatusType Cancelled = new(nameof(Cancelled), 3);

    public TransactionStatusType(string name, int value) : base(name, value)
    {
    }
}
