using Tycho.Contract;
using TychoWebsite.Reactions;
using TychoWebsite.Reactions.Contract;

namespace TychoWebsite.App.Contract.Forwarders;

internal static class ReactionsForwarder
{
    public static IInboxDefinition ForwardReactionsModuleMessages(this IInboxDefinition inboxDefinition)
    {
        return inboxDefinition.Forwards<AddReactionCommand, ReactionsModule>();
    }
}
