using CqrsInDotNet.Data;
using CqrsInDotNet.DTOs;
using CqrsInDotNet.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CqrsInDotNet.Services.ToDos.Commands;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, ResponseTodoDTO>
{
    private readonly DataContext _context;

    public CreateTodoCommandHandler(DataContext context)
    {
        this._context = context;
    }

    public async Task<ResponseTodoDTO> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        EntityEntry<TodoItem> entityEntry = await _context.Todos.AddAsync(new TodoItem()
        {
            Title = request.Todo.Title,
            Description = request.Todo.Description
        }, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseTodoDTO()
        {
            Id = entityEntry.Entity.Id,
            Title = entityEntry.Entity.Title,
            Description = entityEntry.Entity.Description,
        };
    }
}