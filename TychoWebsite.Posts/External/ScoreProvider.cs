using Tycho;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Model.Posts;
using TychoWebsite.Posts.Core.Ports;

namespace TychoWebsite.Posts.External;

internal class ScoreProvider : IPostScoreProvider, ICommentScoresProvider
{
    private readonly IModule _thisModule;

    public ScoreProvider(IModule thisModule)
    {
        _thisModule = thisModule;
    }

    public async Task<PostScore> GetScore(string postId, CancellationToken token)
    {
        return (await GetScores(new[] { postId }, token)).Single();
    }

    public Task<IEnumerable<PostScore>> GetScores(IEnumerable<string> postIds, CancellationToken token)
    {
        return _thisModule.Execute<GetPostsScoresQuery, IEnumerable<PostScore>>(new(postIds), token);
    }
}
