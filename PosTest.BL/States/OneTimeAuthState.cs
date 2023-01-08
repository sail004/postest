using DataAccess.Interfaces;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;
using Pos.Entities.User;

namespace Pos.BL.Implementation.States;

internal class OneTimeAuthState : AbstractState
{
    private readonly IUserRightRepository _userRightRepository;
    protected readonly IUserRepository UserRepository;

    public OneTimeAuthState(IUserRepository userRepository,
        IAuthenticationContext authenticationContext, IUserRightRepository userRightRepository) : base(
        authenticationContext)
    {
        UserRepository = userRepository;
        _userRightRepository = userRightRepository;
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.OneTimeAuthState;


    public PosStateEnum OldState { get; set; }
    public PosStateEnum NewState { get; set; }
    public string ActionLabel { get; set; }

    public override PosStateCommandResult ProcessCommand(AbstractCommand cmd)
    {
        if (CheckPassword(cmd.Body))
        {
            ErrorStatus = string.Empty;
            return new PosStateCommandResult { NewPosState = NewState, HasRights = true };
        }

        ErrorStatus = "Wrong Password";
        return new PosStateCommandResult { NewPosState = OldState, HasRights = false };
    }

    protected virtual bool CheckPassword(string cmd)
    {
        var user = UserRepository.GetByPassword(cmd);
        return user != null && _userRightRepository.UserHasRight(user.Id, ActionLabel);
    }
}