using Microsoft.Extensions.Logging;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoWebsite.Store.Contract.Incoming.Requests;
using TychoWebsite.Store.Core;
using static TychoWebsite.Store.Contract.Incoming.Requests.GetBalance;

namespace TychoWebsite.Store.Messaging.Handlers;

internal class GetBalanceHandler(IUnitOfWork unitOfWork, ILogger<GetBalanceHandler> logger) : IRequestHandler<GetBalance, Response>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<GetBalanceHandler> _logger = logger;

    public async Task<Response> Handle(GetBalance requestData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");
        var account = await _unitOfWork
            .Set<Account>()
            .FindAsync([requestData.AccountId], cancellationToken);

        if (account is null)
        {
            throw new InvalidOperationException($"Failed to get balance of account with ID {requestData.AccountId}");
        }

        _logger.LogInformation("Processing finished");
        return new Response(account.Balance);
    }
}