using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Interfaces
{
    public interface IPosState
    {
        string ErrorState { get; set; }
        PosState NextPosState { get; }
        PosState PosState { get; }

        PosState ProcessCommand(AbstractCommand cmd);
        string SendModel();
    }
}