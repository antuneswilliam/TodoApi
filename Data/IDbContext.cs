using MongoDB.Driver;

public interface IDbContext
{
    IMongoCollection<Todo> Todos { get; }
}
