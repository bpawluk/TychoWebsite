using TychoWebsite.Posts.Contract.Model.Comments;

namespace TychoWebsite.Posts.Core.Ports;

internal interface ICommentsRepository
{
    Task Init();
    Task CreateComment(NewComment comment, CancellationToken token);
    Task<IEnumerable<Comment>> GetComments(string postId, CancellationToken token);
}
