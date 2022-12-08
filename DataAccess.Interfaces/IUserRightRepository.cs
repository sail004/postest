using Pos.Entities.User;

namespace DataAccess.Interfaces
{
    public interface IUserRightRepository : IRepository<UserRight>
    {
        bool UserHasRight(int idUser, int idCommand);
    }
}