using Tycho.Requests;
using static TychoWebsite.Store.Contract.Incoming.Requests.GetBalance;

namespace TychoWebsite.Store.Contract.Incoming.Requests;

public record GetBalance(int AccountId) : IRequest<Response>
{
    public record Response(decimal Amount);
}