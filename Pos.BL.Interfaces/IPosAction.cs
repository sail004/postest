using Pos.Entities.PosStates;

namespace Pos.BL.Interfaces
{
    public interface IPosAction
    {
        PosState NewPosState { get; }
        string ActionLabel { get; }
    }
       
    
}