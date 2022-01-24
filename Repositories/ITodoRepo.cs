public interface ITodoRepo
{
    Task<bool> Delete(string id);
    Task<Todo> Get(string id);
    Task<IEnumerable<Todo>> GetAll();
    Task Insert(Todo todo);
    Task<bool> Update(Todo todo);
}
