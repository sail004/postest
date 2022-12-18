using DataAccess.Interfaces;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

public class AuthState : AbstractState
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRightRepository _userRightRepository;

    public AuthState(IUserRepository userRepository, IUserRightRepository userRightRepository,
        IAuthenticationContext authenticationContext) : base(authenticationContext)
    {
        _userRepository = userRepository;
        _userRightRepository = userRightRepository;
    }

    public override PosState PosState => PosState.AuthState;
    public override PosState NextPosState => PosState.MenuState;

    public override PosActionResult ProcessCommand(AbstractCommand cmd)
    {
        if (CheckPassword(cmd.Body))
        {
            ErrorStatus = string.Empty;
            //Постараться вернуть MenuState из контейнера
            return new PosActionResult { NewPosState = PosState.MenuState, HasRights = true };
        }

        ErrorStatus = "Wrong Password";
        return new PosActionResult { NewPosState = PosState.None, HasRights = false };
    }

    private bool CheckPassword(string cmd)
    {
        AuthenticationContext.User = _userRepository.GetByPassword(cmd);
        if (AuthenticationContext.User == null)
            return false;

        return true;
    }
}