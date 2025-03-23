namespace ToDo.Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(string id);
    }
}
