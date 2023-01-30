using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.PosStates;
using Pos.Entities.Receipt;

public class RegistrationState : AbstractState
{
    private ISerializer<List<ReceiptSpecRecord>> _serializer;


    public RegistrationState(IAuthenticationContext authenticationContext, ISerializer<List<ReceiptSpecRecord>> serializer) : base(authenticationContext)
    {
        _serializer = serializer;
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.RegistrationState;
    public override TransferModel SendModel()
    {
        return new TransferModel { PosStateEnum = PosStateEnum, ErrorStatus = ErrorStatus, JsonData = _serializer.Serialize(new List<ReceiptSpecRecord>() { new ReceiptSpecRecord() {NumPos=1, GoodName = "Шляпа" }, new ReceiptSpecRecord() {NumPos=2, GoodName = "Колбаса" } }), User = AuthenticationContext.User };
    }
}