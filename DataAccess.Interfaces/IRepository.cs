using Pos.Entities.User;

namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T: DataEntity
    {
        public IEnumerable<T> ReadAll();
        public T ReadById(int id);
    }
}