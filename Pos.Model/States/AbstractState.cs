using Pos.Entities.Commands;

namespace Pos.Entities.States
{
    public abstract class AbstractState
    {
        public abstract PosState PosState { get; }
        public virtual PosState NextPosState => PosState.None;

        public string ErrorState { get; set; }

        public virtual string SendModel()
        {
            return $"Activate state {PosState}{Environment.NewLine}";
        }
        public static AbstractState GetInstance(PosState posState)
        {
            switch (posState)
            {
                case PosState.InitState:
                    return new InitState();
                case PosState.AuthState:
                    return new AuthState();
                case PosState.MenuState:
                    return new MenuState();
                case PosState.ExitState:
                    return new ExitState();
                default:
                    return null;
            }

        }

        public virtual PosState ProcessCommand(AbstractCommand cmd)
        {
            return PosState.None;
        }
    }
}