using ToDo.Domain.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.WebApi.Interfaces
{
    public interface IToDoRepository : IRepositoryBase<ToDoEntity>
    {
    }
}