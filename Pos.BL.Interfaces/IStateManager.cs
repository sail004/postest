using Pos.Entities.Commands;
using Pos.Entities.PosStates;

namespace Pos.BL.Interfaces;

public interface IStateManager
{
    IPosState CurrentState { get; }

    public Task SetState(PosStateEnum posStateEnum);
    void ProcessCommand(AbstractCommand cmd);
}