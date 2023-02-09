using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Articles.Core;
using TychoWebsite.Articles.Persistence.Entities;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Articles.Persistence;

internal record ArticlesRepositorySettings : RepositorySettings;

internal class ArticlesRepository : RepositoryBase<NewArticle, ArticleEntity, Article>, IArticlesRepository
{
    private readonly IArticleScoreProvider _articleScoreProvider;

    public ArticlesRepository(
        ArticlesRepositorySettings settings, 
        IArticleScoreProvider articleScoreProvider) : base(settings)
    {
        _articleScoreProvider = articleScoreProvider;
    }

    public Task CreateArticle(NewArticle article, CancellationToken token) => InsertOne(article, token);

    public Task<Article> GetArticle(string articleId, CancellationToken token) => GetById(articleId, token);

    public async Task<IEnumerable<ArticleSummary>> GetArticles(CancellationToken token)
    {
        var entities = await GetAllEntities(token);
        return entities.Select(MapToArticleSummary);
    }

    protected override async Task<Article> MapToModel(ArticleEntity entity, CancellationToken token)
    {
        var score = await _articleScoreProvider.GetScore(entity.Id, token);
        return new Article(
            entity.Id,
            entity.Title,
            entity.Lead,
            entity.Body,
            new Author(entity.Author.Id, entity.Author.Name),
            score,
            entity.PublishingDate,
            entity.Tags,
            entity.IsPublished);
    }

    protected override Task<ArticleEntity> MapToEntity(NewArticle model, CancellationToken token)
    {
        return Task.FromResult(new ArticleEntity()
        {
            Id = model.Id,
            Title = model.Title,
            Lead = model.Lead,
            Body = model.Body,
            Author = new AuthorEntity() { Id = model.Author.Id, Name = model.Author.Name },
            PublishingDate = DateTime.UtcNow,
            Tags = model.Tags,
            IsPublished = true,
            IsArchived = false
        });
    }

    private ArticleSummary MapToArticleSummary(ArticleEntity entity)
    {
        return new ArticleSummary(entity.Id, entity.Title, entity.Lead, entity.PublishingDate);
    }
}
