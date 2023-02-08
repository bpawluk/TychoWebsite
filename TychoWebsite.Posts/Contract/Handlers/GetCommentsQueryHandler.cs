using Tycho.Messaging.Handlers;
using TychoWebsite.Posts.Contract.Model.Comments;
using TychoWebsite.Posts.Core.Ports;

namespace TychoWebsite.Posts.Contract.Handlers;

internal class GetCommentsQueryHandler : IQueryHandler<GetCommentsQuery, IEnumerable<Comment>>
{
    private readonly ICommentsRepository _commentsRepository;

    public GetCommentsQueryHandler(ICommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }

    public Task<IEnumerable<Comment>> Handle(GetCommentsQuery queryData, CancellationToken cancellationToken)
    {
        return _commentsRepository.GetComments(queryData.PostId, cancellationToken);
    }
}
