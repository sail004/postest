using Pos.BL.Interfaces;
using Pos.Entities.PosStates;

namespace Pos.BL.Implementation.States;

public class PosStateResolver
{
    private readonly IEnumerable<IPosState> _posStates;

    public PosStateResolver(IEnumerable<IPosState> posStates)
    {
        _posStates = posStates;
    }

    public IPosState ResolveState(PosState state)
    {
        return _posStates.First(o => o.PosState == state);
    }
}