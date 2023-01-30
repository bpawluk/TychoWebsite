using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TychoWebsite.Shared.Core;

namespace TychoWebsite.Shared.Persistence;

public abstract class RepositoryBase<InputModel, DbEntity, OutputModel>
    where DbEntity : IDatabaseEntity
    where OutputModel : IEntity
{
    protected readonly IMongoCollection<DbEntity> _collection;

    protected FilterDefinition<DbEntity> NotDeleted => Builders<DbEntity>.Filter.Eq(entity => entity.IsArchived, false);

    public RepositoryBase(RepositorySettings settings)
    {
        _collection = new MongoClient(settings.Connection)
            .GetDatabase(settings.Database)
            .GetCollection<DbEntity>(settings.Collection);
    }

    protected abstract Task<OutputModel> MapToModel(DbEntity entity, CancellationToken token);

    protected abstract Task<DbEntity> MapToEntity(InputModel model, CancellationToken token);

    public async Task<IEnumerable<OutputModel>> GetAll(CancellationToken token)
    {
        var entities = await GetAllEntities(token);
        return await Task.WhenAll(entities.Select(async entity => await MapToModel(entity, token)));
    }

    public async Task<OutputModel> GetById(string id, CancellationToken token)
    {
        var entity = await GetEntityById(id, token);
        return await MapToModel(entity, token);
    }

    public async Task InsertOne(InputModel model, CancellationToken token)
    {
        var newEntity = await MapToEntity(model, token);
        await _collection.InsertOneAsync(newEntity, cancellationToken: token);
    }

    protected async Task<IEnumerable<DbEntity>> GetAllEntities(CancellationToken token)
    {
        return (await _collection.FindAsync(NotDeleted, cancellationToken: token)).ToEnumerable(cancellationToken: token);
    }

    protected async Task<DbEntity> GetEntityById(string id, CancellationToken token)
    {
        var filter = Builders<DbEntity>.Filter.Eq(entity => entity.Id, id) & NotDeleted;
        var entity = (await _collection.FindAsync(filter, cancellationToken: token)).SingleOrDefault(cancellationToken: token);
        if (entity is null) throw new DocumentNotFoundException($"There is no document with the given id ({id})");
        return entity;
    } 
}
