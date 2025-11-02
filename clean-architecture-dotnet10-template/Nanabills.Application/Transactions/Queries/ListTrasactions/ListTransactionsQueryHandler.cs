using MediatR;

namespace Nanabills.Application.Transactions.Queries.ListTrasactions
{
    public class ListTransactionsQueryHandler : IRequestHandler<ListTransactionsQuery, string>
    {
        public async Task<string> Handle(ListTransactionsQuery request, CancellationToken cancellationToken)
        {
            return "Transactions list";
        }
    }
}
