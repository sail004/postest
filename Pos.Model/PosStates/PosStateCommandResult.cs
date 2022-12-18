namespace Pos.Entities.PosStates;

public class PosStateCommandResult
{
    public PosStateEnum NewPosState { get; set; }
    public bool HasRights { get; set; }
}

public class PosStateManagerCommandResult
{
    public IPosState NewPosState { get; set; }
    public bool HasRights { get; set; }
}