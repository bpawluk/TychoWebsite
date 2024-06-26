﻿using MongoDB.Driver;
using TychoWebsite.Shared.Persistence;
using TychoWebsite.Topics.Contract.Model;
using TychoWebsite.Topics.Core;
using TychoWebsite.Topics.Persistence.Entities;

namespace TychoWebsite.Topics.Persistence;

internal record TopicsRepositorySettings : RepositorySettings;

internal class TopicsRepository : RepositoryBase<NewTopic, TopicEntity, Topic>, ITopicsRepository
{
    public TopicsRepository(TopicsRepositorySettings settings) : base(settings) { }

    public Task CreateTopic(NewTopic topic, CancellationToken token) => InsertOne(topic, token);

    public Task<Topic> GetTopic(string topicId, CancellationToken token) => GetById(topicId, token);

    public async Task<IEnumerable<Topic>> GetTopics(IEnumerable<string> topicIds, CancellationToken token)
    {
        var filter = Builders<TopicEntity>.Filter.In(entity => entity.Id, topicIds);
        var entities = await FindEntities(filter, token);
        return await MapAllToModel(entities, token);
    }

    protected override Task<TopicEntity> MapToEntity(NewTopic model, CancellationToken token)
    {
        return Task.FromResult(new TopicEntity() { Id = model.Id, Name = model.Name, Tags = model.Tags });
    }

    protected override Task<Topic> MapToModel(TopicEntity entity, CancellationToken token)
    {
        return Task.FromResult(new Topic(entity.Id, entity.Name, entity.Tags));
    }
}
