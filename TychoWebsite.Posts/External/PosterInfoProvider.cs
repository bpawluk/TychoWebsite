using Tycho;
using TychoWebsite.Posts.Contract.Model;
using TychoWebsite.Posts.Core;

namespace TychoWebsite.Posts.External;

internal class PosterInfoProvider : IPosterInfoProvider
{
    public Task<Poster> GetInfo(string posterId, CancellationToken token)
    {
        return Task.FromResult(new Poster(posterId, "Stub Author"));
    }

    public async Task<IEnumerable<Poster>> GetBatchInfo(IEnumerable<string> posterIds, CancellationToken token)
    {
        return await Task.WhenAll(posterIds.Select(async posterId => await GetInfo(posterId, token)));
    }
}
