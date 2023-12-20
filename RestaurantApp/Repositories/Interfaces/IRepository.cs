namespace Repositories.Interface;
public interface IRepository<T>
{
    public T GetOne(int id);
    public void Post(T item);
    public void Delete(int id);
}