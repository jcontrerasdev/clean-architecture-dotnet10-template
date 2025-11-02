using MediatR;

namespace Nanabills.Application.Transactions.Queries.GetTransaction
{
    public class GetTransactionQueryHandler() : IRequestHandler<GetTransactionQuery, string>
    {
        public async Task<string> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            return "Transaction details";
        }
    }
}
