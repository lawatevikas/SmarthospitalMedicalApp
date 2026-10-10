namespace Clinora.Infrastructure.Configuration;

public sealed class MongoDbOptions
{
    public const string SectionName = "MongoDB";

    public string ConnectionString { get; set; } = string.Empty;

    public string DatabaseName { get; set; } = "Clinora_Development";
}
