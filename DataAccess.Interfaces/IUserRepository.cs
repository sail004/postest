using Pos.Entities.User;

namespace DataAccess.Interfaces;

public interface IUserRepository : IRepository<User>
{
    User? GetByPassword(string password);
}