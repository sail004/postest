using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Interfaces;

public interface IStateManager
{
    IPosState CurrentState { get; }

    public void SetState(PosStateEnum posStateEnum, PosStateEnum nextStateEnum = PosStateEnum.None);
    void ProcessCommand(AbstractCommand cmd);
}