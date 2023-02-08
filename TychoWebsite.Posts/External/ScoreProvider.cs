using Tycho;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Posts.Contract.Model.Comments;
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

    async Task<PostScore> IPostScoreProvider.GetScore(string postId, CancellationToken token)
    {
        return (await (this as IPostScoreProvider).GetScores(new[] { postId }, token)).Single();
    }

    Task<IEnumerable<PostScore>> IPostScoreProvider.GetScores(IEnumerable<string> postIds, CancellationToken token)
    {
        return _thisModule.Execute<GetPostsScoresQuery, IEnumerable<PostScore>>(new(postIds), token);
    }

    async Task<CommentScore> ICommentScoresProvider.GetScore(string commentId, CancellationToken token)
    {
        return (await (this as ICommentScoresProvider).GetScores(new[] { commentId }, token)).Single();
    }

    Task<IEnumerable<CommentScore>> ICommentScoresProvider.GetScores(IEnumerable<string> commentIds, CancellationToken token)
    {
        return _thisModule.Execute<GetCommentsScoresQuery, IEnumerable<CommentScore>>(new(commentIds), token);
    }
}
