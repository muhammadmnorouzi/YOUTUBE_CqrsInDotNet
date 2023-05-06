using CqrsInDotNet.DTOs;
using MediatR;

namespace CqrsInDotNet.Services.ToDos.Queries;

public class GetTodoByIdQuery : IRequest<ResponseTodoDTO?>
{
    public GetTodoByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}