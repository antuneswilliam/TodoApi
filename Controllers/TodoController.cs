using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{

    private readonly ITodoRepo todoRepo;

    public TodoController(ITodoRepo todoRepo)
    {
        this.todoRepo = todoRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var todos = await todoRepo.GetAll();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var todo = await todoRepo.Get(id);

        if (todo == null)
            return NotFound(id);

        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Todo todo)
    {
        await todoRepo.Insert(todo);
        return CreatedAtRoute("", new {id = todo.Id},  todo);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Todo todo)
    {
        var result = await todoRepo.Update(todo);

        if (!result)
            return NotFound(todo);

        return Ok(todo);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(string id)
    {
        var result = await todoRepo.Delete(id);

        if (!result)
            return NotFound(id);

        return Ok(id);
    }
}