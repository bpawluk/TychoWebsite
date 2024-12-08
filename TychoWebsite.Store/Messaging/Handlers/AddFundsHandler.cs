using Microsoft.Extensions.Logging;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoWebsite.Store.Contract.Incoming.Requests;
using TychoWebsite.Store.Core;

namespace TychoWebsite.Store.Messaging.Handlers;

internal class AddFundsHandler(IUnitOfWork unitOfWork, ILogger<AddFundsHandler> logger) : IRequestHandler<AddFunds>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<AddFundsHandler> _logger = logger;

    public async Task Handle(AddFunds requestData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");
        var account = await _unitOfWork
            .Set<Account>()
            .FindAsync([requestData.AccountId], cancellationToken);

        if (account is null)
        {
            throw new InvalidOperationException($"Failed to add funds to account with ID {requestData.AccountId}");
        }
        account.Deposit(requestData.Amount);

        await _unitOfWork.SaveChanges(cancellationToken);
        _logger.LogInformation("Processing finished");
    }
}