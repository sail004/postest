using Pos.BL.Implementation.Environment;
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
    private ReceiptModel _receiptModel;

    public RegistrationState(IAuthenticationContext authenticationContext, ISerializer<RegistrationStateModel> serializer) : base(authenticationContext)
    {
        _serializer = serializer;
        _receiptModel = new ReceiptModel()
        {
            ReceiptSpecRecords = new List<ReceiptSpecRecord>() { new ReceiptSpecRecord() { NumPos = 1, GoodName = "Шляпа", Amount = 1, Price = 45 }, new ReceiptSpecRecord() { NumPos = 2, GoodName = "Колбаса" } },
            ReceiptNumber = 1,
            ShiftNumber = 3,
            Cashier = "Кассир1",
            PaymentType = 2,
            AmountWithoutDiscount = 111,
            Discount = 10
        };
        _registrationModel = BuildRegistrationModel(_receiptModel);
     
    }

    private static RegistrationStateModel BuildRegistrationModel(ReceiptModel receiptModel)
    {
        return new RegistrationStateModel()
        {
            Receipt = receiptModel,
            InputValue = string.Empty,
            Status = string.Empty,
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
        _registrationModel.ErrorOccured = false;
        if (AbstractCommand.CommandLableInfo.ContainsKey(cmd.CommandLabel))
        {
            _registrationModel.Status = AbstractCommand.CommandLableInfo[cmd.CommandLabel];
        }
        else
        {
            _registrationModel.Status = string.Empty;
        }
        switch (cmd.CommandLabel)
        {
            case CommandLabel.Data:
                _registrationModel.InputValue += cmd.Body;
                break;
            case CommandLabel.Backspace:
                _registrationModel.InputValue = _registrationModel.InputValue.Substring(0, _registrationModel.InputValue.Length - 1);
                break;
            case CommandLabel.MoveDown:
                _registrationModel.IncrementPosition();
                break;
            case CommandLabel.MoveUp:
                _registrationModel.DecrementPosition();
                break;
            case CommandLabel.BarcodeReceived:
                _registrationModel.InputValue = cmd.Body;
                break;
            case CommandLabel.ErrorHandling:
                _registrationModel.Status = cmd.Body;
                _registrationModel.InputValue = string.Empty;
                _registrationModel.ErrorOccured = true;
                break;
            case CommandLabel.PriceChanged:
                _receiptModel.ReceiptSpecRecords[_registrationModel.CurrentPosition].Price =
                    decimal.Parse(_registrationModel.InputValue);
                _registrationModel.InputValue = string.Empty;
                break;
            case CommandLabel.AmountChanged:
                _receiptModel.ReceiptSpecRecords[_registrationModel.CurrentPosition].Amount =
                    double.Parse(_registrationModel.InputValue);
                _registrationModel.InputValue = string.Empty;
                break;
            case CommandLabel.DeletingPosition:
                _receiptModel.ReceiptSpecRecords[_registrationModel.CurrentPosition].IsDeleted = true;
                _registrationModel.IncrementPosition();
                break;

        }

        return new PosStateCommandResult { NewPosState = PosStateEnum.RegistrationState, HasRights = true };
    }
}