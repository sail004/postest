using DataAccess.Interfaces;
using Pos.BL.Interfaces;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;
using Pos.Entities.User;

namespace Pos.BL.Implementation.States
{
    public abstract class AbstractState : IPosState
    {
        public AbstractState(IAuthenticationContext authenticationContext)
        {
            AuthenticationContext = authenticationContext;
        }
        protected IAuthenticationContext AuthenticationContext;

        public abstract PosState PosState { get; }
        public virtual PosState NextPosState => PosState.None;

        public string ErrorStatus { get; set; }

        public virtual string SendModel()
        {
            return $"Activate state {PosState}{Environment.NewLine}";
        }

        public virtual PosActionResult ProcessCommand(AbstractCommand cmd)
        {
            var posAction = GetAction(cmd);

            if (CheckRights(posAction))
                return new PosActionResult { NewPosState =posAction.NewPosState , HasRights = true };
            
           return new PosActionResult { NewPosState = posAction.NewPosState, HasRights = false };
        }

        private bool CheckRights(IPosAction posAction)
        {
            if (AuthenticationContext.User == null)
                return false;

            return true;
        }

        protected virtual IPosAction GetAction(AbstractCommand cmd)
        {
            return new EmptyAction() { };
        }
       
    }
}