using Pos.Entities.PosStates;

namespace Pos.BL.Interfaces;

public interface IPosAction
{
    PosStateEnum NewPosStateEnum { get; }
    string ActionLabel { get; }
}