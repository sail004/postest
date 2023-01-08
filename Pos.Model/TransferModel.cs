using Pos.Entities.PosStates;

namespace Pos.Entities;

public class TransferModel
{
    public PosStateEnum PosStateEnum;
    public string JsonData { get; set; }
    public string ErrorStatus { get; set; }
}