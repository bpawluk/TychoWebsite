using TychoWebsite.Posts.Contract.Model;

namespace TychoWebsite.Posts.Core;

internal interface IPosterInfoProvider
{
    Task<Poster> GetInfo(string posterId, CancellationToken token);
    Task<IEnumerable<Poster>> GetBatchInfo(IEnumerable<string> posterIds, CancellationToken token);
}
