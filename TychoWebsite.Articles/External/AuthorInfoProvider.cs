using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Articles.Core.Ports;

namespace TychoWebsite.Articles.External;

internal class AuthorInfoProvider : IAuthorInfoProvider
{
    public Task<Author> GetInfo(string authorId, CancellationToken token)
    {
        return Task.FromResult(new Author(authorId, "Stub Author"));
    }
}
