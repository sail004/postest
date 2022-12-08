using DataAccess.Interfaces;
using Pos.Entities.User;


namespace DataAcces.Implementation
{
    public class UserRightRespoitory : IUserRightRepository
    {
        List<Command> _testComandModel = new List<Command> {
            new Command { CommandLabel="Menu", Id = 1, Name = "Меню"},
            new Command { CommandLabel="Registration", Id = 2, Name="Регистрация"},
            new Command { CommandLabel="Report", Id = 3, Name="Отчеты"},
            new Command { CommandLabel="Exit", Id = 4, Name="Выход"}
        };
        List<UserRight> _testModel = new List<UserRight> {
            new UserRight { IdUser = 1, IdCommand = 1 },
            new UserRight { IdUser = 2, IdCommand = 1 },
            new UserRight { IdUser = 1, IdCommand = 4 },
            new UserRight { IdUser = 2, IdCommand = 4 },
            new UserRight { IdUser = 1, IdCommand = 2 },
            new UserRight { IdUser = 2, IdCommand = 2 },
            new UserRight { IdUser = 1, IdCommand = 3 },

        };
        public IEnumerable<UserRight> ReadAll()
        {
            throw new NotImplementedException();
        }

        public UserRight ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UserHasRight(int idUser, int idCommand)
        {
            return _testModel.Any(x => x.IdUser == idUser && x.IdCommand == idCommand);
        }
    }
}