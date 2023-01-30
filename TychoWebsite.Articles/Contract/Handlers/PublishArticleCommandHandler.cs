﻿using Tycho;
using Tycho.Messaging.Handlers;
using TychoWebsite.Articles.Core.Ports;

namespace TychoWebsite.Articles.Contract.Handlers;

internal class PublishArticleCommandHandler : ICommandHandler<PublishArticleCommand>
{
    private readonly IModule _thisModule;
    private readonly IArticlesRepository _articlesRepository;

    public PublishArticleCommandHandler(IModule thisModule, IArticlesRepository articlesRepository)
    {
        _thisModule = thisModule;
        _articlesRepository = articlesRepository;
    }

    public async Task Handle(PublishArticleCommand commandData, CancellationToken cancellationToken)
    {
        await _thisModule.Execute<CreateArticleTopicCommand>(new(commandData.Article.Id), cancellationToken);
        await _articlesRepository.CreateArticle(commandData.Article, cancellationToken);
    }
}
