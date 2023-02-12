using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.Commands;
using Pos.Entities.PosStates;
using Pos.Entities.Receipt;

namespace Pos.BL.Implementation.States;

public class RegistrationState : AbstractState
{
    private readonly ISerializer<RegistrationStateModel> _serializer;
    private readonly RegistrationStateModel _registrationModel;

    public RegistrationState(IAuthenticationContext authenticationContext, ISerializer<RegistrationStateModel> serializer) : base(authenticationContext)
    {
        _serializer = serializer;
        var receiptModel = new ReceiptModel()
        {
            ReceiptSpecRecords = new List<ReceiptSpecRecord>() { new ReceiptSpecRecord() { NumPos = 1, GoodName = "Шляпа" }, new ReceiptSpecRecord() { NumPos = 2, GoodName = "Колбаса" } },
            ReceiptNumber = 1,
            Total = 100,
            ShiftNumber = 3,
            Cashier = "Кассир1",
            PaymentType = 2,
            AmountWithoutDiscount = 111,
            Discount = 10
        };
        _registrationModel = new RegistrationStateModel()
        {

            Receipt= receiptModel,
            InputValue = "123",
            Status = "вввод шк",
            CurrentPosition = 0
        };


    }

    public override PosStateEnum PosStateEnum => PosStateEnum.RegistrationState;
    public override TransferModel SendModel()
    {
        return new TransferModel { PosStateEnum = PosStateEnum, ErrorStatus = ErrorStatus, JsonData = _serializer.Serialize(_registrationModel), User = AuthenticationContext.User };
    }
    public override PosStateCommandResult ProcessCommand(AbstractCommand cmd)
    {
        switch (cmd.CommandLabel)
        {
            case CommandLabel.Data:
                _registrationModel.InputValue = cmd.Body;
                break;
            case CommandLabel.MoveDown:
                _registrationModel.IncrementPosition();
                break;
            case CommandLabel.MoveUp:
                _registrationModel.DecrementPosition();
                break;
        }

        return new PosStateCommandResult { NewPosState = PosStateEnum.RegistrationState, HasRights = true };
    }
}