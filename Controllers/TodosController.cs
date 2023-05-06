using CqrsInDotNet.DTOs;
using CqrsInDotNet.Services.ToDos;
using CqrsInDotNet.Services.ToDos.Commands;
using CqrsInDotNet.Services.ToDos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsInDotNet.Controllers;

[ApiController]
[Route("[controller]")]
public class TodosController : ControllerBase
{
    private readonly IMediator _mediator;

    public TodosController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<ResponseTodoDTO>> CreateTodo([FromBody] CreateTodoDTO createTodoDTO)
    {
        var result = await _mediator.Send(new CreateTodoCommand(createTodoDTO));

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ResponseTodoDTO>>> GetTodos()
    {
        var result = await _mediator.Send(new GetTodosQuery());

        return Ok(result);
    }

    [HttpGet("/{id}")]
    public async Task<ActionResult<ResponseTodoDTO?>> GetTodoById(int id)
    {
        var result = await _mediator.Send(new GetTodoByIdQuery(id));

        return Ok(result);
    }
}