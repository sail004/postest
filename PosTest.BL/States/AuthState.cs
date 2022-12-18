using DataAccess.Interfaces;
using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

public class AuthState : OneTimeAuthState
{
    public AuthState(IUserRepository userRepository, IAuthenticationContext authenticationContext,
        IUserRightRepository userRightRepository) : base(userRepository, authenticationContext, userRightRepository)
    {
        NewState = PosStateEnum.MenuState;
        OldState = PosStateEnum.AuthState;
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.AuthState;

    protected override bool CheckPassword(string cmd)
    {
        var user = UserRepository.GetByPassword(cmd);
        if (user != null)
            AuthenticationContext.User = user;
        return user != null;
    }
}