using Tycho.Contract;
using TychoWebsite.Topics;
using TychoWebsite.Topics.Contract;

namespace TychoWebsite.App.Contract.Forwarders;

internal static class TopicsForwarder
{
    public static IInboxDefinition ForwardTopicsModuleMessages(this IInboxDefinition inboxDefinition)
    {
        return inboxDefinition.Forwards<CreateTopicCommand, TopicsModule>();
    }
}
