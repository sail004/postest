using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Interfaces
{
    public interface IPosState
    {
        string ErrorStatus { get; set; }
        PosState NextPosState { get; }
        PosState PosState { get; }

        PosActionResult ProcessCommand(AbstractCommand cmd);
        string SendModel();
    }

    
    
}