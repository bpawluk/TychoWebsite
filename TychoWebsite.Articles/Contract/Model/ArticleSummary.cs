﻿using TychoWebsite.Shared.Core;

namespace TychoWebsite.Articles.Contract.Model;

public record ArticleSummary(
    string Id,
    string Title,
    string Lead,
    DateTime PublishingDate) : IEntity;
