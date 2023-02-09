using Microsoft.Extensions.Configuration;

namespace TychoWebsite.Shared.Extensions;

public static class IConfigurationExtensions
{
    public static T? GetSection<T>(this IConfiguration config) where T : class => config
        .GetSection(typeof(T).Name)?
        .Get<T>();
}
