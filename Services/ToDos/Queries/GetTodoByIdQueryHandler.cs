using System.Runtime.CompilerServices;
using CqrsInDotNet.Data;
using CqrsInDotNet.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace CqrsInDotNet.Services.ToDos.Queries;

public class GetToDoByIdQueryHandler : IRequestHandler<GetTodoByIdQuery, ResponseTodoDTO?>
{
    private readonly DataContext _context;

    public GetToDoByIdQueryHandler(DataContext context)
    {
        this._context = context;
    }

    public async Task<ResponseTodoDTO?> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Todos
            .Where(todo => todo.Id == request.Id)
            .Select(todo => new ResponseTodoDTO()
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}