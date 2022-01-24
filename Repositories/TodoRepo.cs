using MongoDB.Driver;

public class TodoRepo : ITodoRepo
{
    private readonly IDbContext context;

    public TodoRepo(IDbContext context)
    {
        this.context = context;
    }

    public async Task<Todo> Get(string id)
    {
        return await context.Todos.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Todo>> GetAll()
    {
        return await context.Todos.Find(x => true).ToListAsync();
    }

    public async Task Insert(Todo todo)
    {
        await context.Todos.InsertOneAsync(todo);
    }

    public async Task<bool> Update(Todo todo)
    {
        var result = await context.Todos.ReplaceOneAsync(x => x.Id == todo.Id, todo);

        return result.IsAcknowledged
            && result.ModifiedCount > 0;

    }

    public async Task<bool> Delete(string id)
    {
        var result = await context.Todos.DeleteOneAsync(x => x.Id == id);

        return result.IsAcknowledged
            && result.DeletedCount > 0;
    }

}