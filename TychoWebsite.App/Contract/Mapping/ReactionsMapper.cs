﻿using TychoWebsite.Articles.Contract;
using TychoWebsite.Posts.Contract;
using TychoWebsite.Reactions.Contract;

namespace TychoWebsite.App.Contract.Mapping;

internal class ReactionsMapper
{
    public static NewReactionSubjectAvailableEvent MapEvent(ArticlePublishedEvent eventData)
    {
        return new(eventData.ArticleId);
    }

    public static NewReactionSubjectAvailableEvent MapEvent(PostPublishedEvent eventData)
    {
        return new(eventData.PostId);
    }

    public static NewReactionSubjectAvailableEvent MapEvent(CommentPublishedEvent eventData)
    {
        return new(eventData.CommentId);
    }

    public static GetScoreQuery MapQuery(GetArticleScoreQuery queryData)
    {
        return new(queryData.ArticleId);
    }

    public static GetScoresQuery MapQuery(GetCommentsScoresQuery queryData)
    {
        return new(queryData.CommentIds);
    }

    public static GetScoresQuery MapQuery(GetPostsScoresQuery queryData)
    {
        return new(queryData.PostIds);
    }
}
