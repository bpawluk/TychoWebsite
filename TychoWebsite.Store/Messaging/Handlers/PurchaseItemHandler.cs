using Microsoft.Extensions.Logging;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoWebsite.Store.Contract.Incoming.Requests;
using TychoWebsite.Store.Contract.Outgoing.Events;
using TychoWebsite.Store.Core;

namespace TychoWebsite.Store.Messaging.Handlers;

internal class PurchaseItemHandler(IUnitOfWork unitOfWork, ILogger<PurchaseItemHandler> logger) : IRequestHandler<PurchaseItem>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<PurchaseItemHandler> _logger = logger;

    public async Task Handle(PurchaseItem requestData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");

        var item = await _unitOfWork
            .Set<Item>()
            .FindAsync([requestData.ItemId], cancellationToken);

        if (item is null)
        {
            throw new InvalidOperationException($"Failed to purchase item with ID {requestData.ItemId}");
        }

        var account = await _unitOfWork
            .Set<Account>()
            .FindAsync([requestData.PurchaserId], cancellationToken);

        if (account is null)
        {
            throw new InvalidOperationException($"Failed to purchase item for account with ID {requestData.PurchaserId}");
        }

        account.Withdraw(item.Price);
        await _unitOfWork.Publish(new ItemPurchased(account.Id, item.Id));
        await _unitOfWork.SaveChanges(cancellationToken);

        _logger.LogInformation("Processing finished");
    }
}