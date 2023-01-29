using Tycho;
using TychoWebsite.App.Contract;
using TychoWebsite.App.Contract.Model;

namespace TychoWebsite.App.Extensions;

public static class IModuleExtensions
{
    public async static Task<T> GetService<T>(this IModule app) 
        where T : class, IService
    {
        return (T)await app.Execute<GetServiceQuery, IService>(new(typeof(T)));
    }
}
