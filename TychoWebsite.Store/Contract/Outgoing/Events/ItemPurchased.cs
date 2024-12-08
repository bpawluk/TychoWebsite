using Tycho.Events;

namespace TychoWebsite.Store.Contract.Outgoing.Events;

public record ItemPurchased(int PurchaserId, int ItemId) : IEvent;