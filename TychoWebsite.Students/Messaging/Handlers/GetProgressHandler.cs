using Tycho.Requests;
using TychoWebsite.Students.Contract.Incoming.Requests;
using static TychoWebsite.Students.Contract.Incoming.Requests.GetProgress;

namespace TychoWebsite.Students.Messaging.Handlers;

internal class GetProgressHandler : IRequestHandler<GetProgress, Response>
{
    public Task<Response> Handle(GetProgress requestData, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}