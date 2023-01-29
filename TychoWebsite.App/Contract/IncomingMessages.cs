using Tycho.Messaging.Payload;
using TychoWebsite.App.Contract.Model;

namespace TychoWebsite.App.Contract;

public record GetServiceQuery(Type ServiceType) : IQuery<IService>;
