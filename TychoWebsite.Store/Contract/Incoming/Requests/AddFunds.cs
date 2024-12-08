using Tycho.Requests;

namespace TychoWebsite.Store.Contract.Incoming.Requests;

public record AddFunds(int AccountId, decimal Amount) : IRequest;