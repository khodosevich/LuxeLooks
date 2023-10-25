namespace LuxeLooks.DataManagment.Repositories.Interfaces;

public interface IBaseRepository<T>
{
    Task Create(T? entity);
    Task<List<T>> GetAll();
    Task Delete(T? entity);
    Task<T> Update(T entity);
}