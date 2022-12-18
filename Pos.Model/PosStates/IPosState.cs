using Pos.Entities.Commands;

namespace Pos.Entities.PosStates;

public interface IPosState
{
    string ErrorStatus { get; set; }
    PosStateEnum PosStateEnum { get; }

    PosStateCommandResult ProcessCommand(AbstractCommand cmd);
    string SendModel();
}