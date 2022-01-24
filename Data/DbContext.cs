using MongoDB.Driver;

public class DbContext : IDbContext
{
    public DbContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Todos = database.GetCollection<Todo>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
    }

    public IMongoCollection<Todo> Todos { get; }
}