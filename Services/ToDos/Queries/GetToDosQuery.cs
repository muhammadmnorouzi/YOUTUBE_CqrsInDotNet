using CqrsInDotNet.DTOs;
using MediatR;

namespace CqrsInDotNet.Services.ToDos;

public class GetTodosQuery : IRequest<IEnumerable<ResponseTodoDTO>>
{

}