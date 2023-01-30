using TychoWebsite.Articles.Contract.Model;

namespace TychoWebsite.Articles.Core.Ports;

internal interface IAuthorInfoProvider
{
    Task<Author> GetInfo(string authorId, CancellationToken token);
}
