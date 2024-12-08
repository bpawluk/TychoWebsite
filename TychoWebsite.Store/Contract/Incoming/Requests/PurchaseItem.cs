using Tycho.Requests;

namespace TychoWebsite.Store.Contract.Incoming.Requests;

public record PurchaseItem(int PurchaserId, int ItemId) : IRequest;