using MongoDB.Driver;
using TychoWebsite.Reactions.Contract.Model;
using TychoWebsite.Reactions.Core;
using TychoWebsite.Shared.Persistence;
using TychoWebsite.Topics.Persistence.Entities;

namespace TychoWebsite.Topics.Persistence;

internal record ReactionsRepositorySettings : RepositorySettings;

internal class ReactionsRepository : RepositoryBase<Reaction, ReactionsEntity, Score>, IReactionsRepository
{
    public ReactionsRepository(ReactionsRepositorySettings settings) : base(settings) { }

    public async Task Init(string subjectId, CancellationToken token)
    {
        var newReactionsEntity = new ReactionsEntity() 
        { 
            Id = subjectId,
            SenderIds = Array.Empty<string>(),
            IsArchived = false
        };
        await _collection.InsertOneAsync(newReactionsEntity, cancellationToken: token);
    }

    public async Task AddReaction(Reaction reaction, CancellationToken token)
    {
        var filter = Builders<ReactionsEntity>.Filter.Eq(entity => entity.Id, reaction.SubjectId);
        var update = Builders<ReactionsEntity>.Update.AddToSet(entity => entity.SenderIds, reaction.SenderId);
        await _collection.UpdateOneAsync(filter & NotDeleted, update, cancellationToken: token);
    }

    public Task<Score> GetScore(string subjectId, CancellationToken token) => GetById(subjectId, token);

    public async Task<IEnumerable<Score>> GetScores(IEnumerable<string> subjectIds, CancellationToken token)
    {
        var filter = Builders<ReactionsEntity>.Filter.In(entity => entity.Id, subjectIds);
        var entities = await FindEntities(filter, token);
        return await MapAllToModel(entities, token);
    }

    protected override Task<ReactionsEntity> MapToEntity(Reaction model, CancellationToken token)
    {
        throw new InvalidOperationException("Mapping to a database entity is not supported for this model");
    }

    protected override Task<Score> MapToModel(ReactionsEntity entity, CancellationToken token)
    {
        return Task.FromResult(new Score(entity.Id, entity.SenderIds.Count()));
    }
}
