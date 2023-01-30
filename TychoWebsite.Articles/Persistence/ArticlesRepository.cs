using TychoWebsite.Articles.Contract.Model;
using TychoWebsite.Articles.Core.Ports;
using TychoWebsite.Articles.Persistence.Entities;
using TychoWebsite.Shared.Persistence;

namespace TychoWebsite.Articles.Persistence;

internal class ArticlesRepository : RepositoryBase<NewArticle, ArticleEntity, Article>, IArticlesRepository
{
    private readonly IAuthorInfoProvider _authorProvider;
    private readonly IArticleScoreProvider _articleScoreProvider;

    public ArticlesRepository(IAuthorInfoProvider authorProvider, IArticleScoreProvider articleScoreProvider) 
        : base(new RepositorySettings(@"mongodb://localhost:27017", "articlesModule", "articles"))
    {
        _authorProvider = authorProvider;
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
        var author = await _authorProvider.GetInfo(entity.Author, token);
        var score = await _articleScoreProvider.GetScore(entity.Id, token);
        return new Article(
            entity.Id,
            entity.Title,
            entity.Lead,
            entity.Body,
            author,
            score,
            entity.PublishingDate,
            entity.Tags,
            entity.IsPublished,
            entity.IsArchived);
    }

    protected override Task<ArticleEntity> MapToEntity(NewArticle model, CancellationToken token)
    {
        return Task.FromResult(new ArticleEntity()
        {
            Id = model.Id,
            Title = model.Title,
            Lead = model.Lead,
            Body = model.Body,
            Author = model.Author,
            PublishingDate = DateTime.UtcNow,
            Tags = model.Tags,
            IsArchived = false
        });
    }

    private ArticleSummary MapToArticleSummary(ArticleEntity entity)
    {
        return new ArticleSummary(entity.Id, entity.Title, entity.Lead, entity.PublishingDate);
    }
}
