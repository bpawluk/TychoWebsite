using TychoWebsite.Posts.Contract.Model.Comments;

namespace TychoWebsite.Posts.Core.Ports;

internal interface ICommentScoresProvider
{
    Task<CommentScore> GetScore(string commentId, CancellationToken token);
    Task<IEnumerable<CommentScore>> GetScores(IEnumerable<string> commentIds, CancellationToken token);
}
