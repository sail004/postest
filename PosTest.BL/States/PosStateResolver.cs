using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

internal class PosStateResolver
{
    private readonly IEnumerable<IPosState> _posStates;

    public PosStateResolver(IEnumerable<IPosState> posStates)
    {
        _posStates = posStates;
    }

    public IPosState? ResolveState(PosStateEnum stateEnum)
    {
        return _posStates.FirstOrDefault(o => o.PosStateEnum == stateEnum);
    }
}