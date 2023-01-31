using TychoWebsite.Posts.Contract.Model.Posts;

namespace TychoWebsite.Posts.Core.Ports;

internal interface IPostScoreProvider
{
    Task<PostScore> GetScore(string postId, CancellationToken token);
    Task<IEnumerable<PostScore>> GetScores(IEnumerable<string> postIds, CancellationToken token);
}
