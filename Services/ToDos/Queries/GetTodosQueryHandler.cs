using CqrsInDotNet.Data;
using CqrsInDotNet.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsInDotNet.Services.ToDos.Queries;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<ResponseTodoDTO>>
{
    private readonly DataContext _context;

    public GetTodosQueryHandler(DataContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<ResponseTodoDTO>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Todos
            .Select(todo => new ResponseTodoDTO()
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description
            })
            .ToArrayAsync(cancellationToken);
    }
}