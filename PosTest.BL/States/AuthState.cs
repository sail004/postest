using DataAccess.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;
using Pos.Entities.User;

namespace Pos.BL.Implementation.States
{
    public class AuthState : AbstractState
    {
        private readonly IUserRepository _userRepository;
        
        public User AuthenticatedUser;
        public AuthState(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public override PosState PosState => PosState.AuthState;
        public override PosState NextPosState => PosState.MenuState;
        public override PosState ProcessCommand(AbstractCommand cmd)
        {
            if (CheckPassword(cmd.Body))
            {
                ErrorState = "";
                return NextPosState;
            }


            ErrorState = "Wrong Password";
            return PosState.None;
        }
        private bool CheckPassword(string cmd)
        {
            AuthenticatedUser = _userRepository.GetByPassword(cmd);
            if (AuthenticatedUser == null)
                return false;
            
            return true;
        }
    }
}
