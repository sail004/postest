using DataAccess.Interfaces;
using Pos.Entities.User;

namespace DataAcces.Implementation;

public class UserRightRepository : IUserRightRepository
{
    private readonly List<UserRight> _testModel = new()
    {
        new UserRight() { IdUser = 1, IdAction = 1 },
        new UserRight() { IdUser = 2, IdAction = 1 },
        new UserRight() { IdUser = 1, IdAction = 4 },
        new UserRight() { IdUser = 2, IdAction = 4 },
        new UserRight() { IdUser = 1, IdAction = 2 },
        new UserRight() { IdUser = 2, IdAction = 2 },
        new UserRight() { IdUser = 1, IdAction = 3 }
    };

    private readonly List<UserAction> _testUserActionModel = new()
    {
        new UserAction() { ActionLabel = "Menu", Id = 1, Name = "Меню" },
        new UserAction() { ActionLabel = "Registration", Id = 2, Name = "Регистрация" },
        new UserAction() { ActionLabel = "Report", Id = 3, Name = "Отчеты" },
        new UserAction() { ActionLabel = "Exit", Id = 4, Name = "Выход" }
    };

    public IEnumerable<UserRight> ReadAll()
    {
        throw new NotImplementedException();
    }

    public UserRight ReadById(int id)
    {
        throw new NotImplementedException();
    }

    public bool UserHasRight(int idUser, string actionLabel)
    {
        var action = _testUserActionModel.FirstOrDefault(x => x.ActionLabel == actionLabel);
        return _testModel.Any(x => x.IdUser == idUser && x.IdAction == action?.Id);
    }
}