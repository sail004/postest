using DataAccess.Interfaces;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

public class AuthState : AbstractState
{
    private readonly IUserRepository _userRepository;

    public AuthState(IUserRepository userRepository,
        IAuthenticationContext authenticationContext) : base(authenticationContext)
    {
        _userRepository = userRepository;
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.AuthState;


    public override PosStateCommandResult ProcessCommand(AbstractCommand cmd)
    {
        if (CheckPassword(cmd.Body))
        {
            ErrorStatus = string.Empty;
            //Постараться вернуть MenuState из контейнера
            return new PosStateCommandResult { NewPosState = PosStateEnum.None, HasRights = true };
        }

        ErrorStatus = "Wrong Password";
        return new PosStateCommandResult { NewPosState = PosStateEnum.None, HasRights = false };
    }

    private bool CheckPassword(string cmd)
    {
        AuthenticationContext.User = _userRepository.GetByPassword(cmd);
        if (AuthenticationContext.User == null)
            return false;

        return true;
    }
}