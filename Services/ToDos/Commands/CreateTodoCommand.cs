using CqrsInDotNet.DTOs;
using MediatR;

namespace CqrsInDotNet.Services.ToDos.Commands;

public class CreateTodoCommand : IRequest<ResponseTodoDTO>
{
    public CreateTodoCommand(CreateTodoDTO todo)
    {
        Todo = todo;
    }

    public CreateTodoDTO Todo { get; set; } = default!;
}