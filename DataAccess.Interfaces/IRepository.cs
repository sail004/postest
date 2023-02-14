using Pos.Entities.User;

namespace DataAccess.Interfaces;

public interface IRepository<T> where T : DataEntity
{
    public Task<IEnumerable<T>> ReadAllAsync();
    public T ReadById(int id);
}
