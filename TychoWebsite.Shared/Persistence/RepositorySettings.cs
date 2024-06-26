﻿namespace TychoWebsite.Shared.Persistence;

public record RepositorySettings
{
    public string Connection { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
    public string Collection { get; set; } = string.Empty;
}
