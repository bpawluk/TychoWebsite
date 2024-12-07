using Microsoft.Extensions.Logging;
using Tycho.Persistence.EFCore;
using Tycho.Requests;
using TychoWebsite.Rating.Contract.Incoming.Requests;
using TychoWebsite.Rating.Contract.Outgoing.Events;
using TychoWebsite.Rating.Core;

namespace TychoWebsite.Rating.Messaging.Handlers;

internal class RateHandler(IUnitOfWork unitOfWork, ILogger<RateHandler> logger) : IRequestHandler<Rate>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<RateHandler> _logger = logger;

    public async Task Handle(Rate requestData, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing started");
        var target = await _unitOfWork
            .Set<Target>()
            .FindAsync([requestData.TargetId], cancellationToken);

        if (target is null)
        {
            throw new InvalidOperationException($"Failed to rate target with ID {requestData.TargetId}");
        }

        target.Rate(requestData.NumberOfStars);
        await _unitOfWork.Publish(new RatingChanged(target.Id, target.GetRating()));

        await _unitOfWork.SaveChanges(cancellationToken);
        _logger.LogInformation("Processing finished");
    }
}