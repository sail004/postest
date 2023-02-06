using Pos.BL.Implementation.States;
using Pos.BL.Interfaces;
using Pos.Entities;
using Pos.Entities.PosStates;
using Pos.Entities.Receipt;

public class RegistrationState : AbstractState
{
    private ISerializer<RegistrationStateModel> _serializer;


    public RegistrationState(IAuthenticationContext authenticationContext, ISerializer<RegistrationStateModel> serializer) : base(authenticationContext)
    {
        _serializer = serializer;
    }

    public override PosStateEnum PosStateEnum => PosStateEnum.RegistrationState;
    public override TransferModel SendModel()
    {
        return new TransferModel { PosStateEnum = PosStateEnum, ErrorStatus = ErrorStatus, JsonData = _serializer.Serialize(

            new RegistrationStateModel()
            {

                Receipt = new ReceiptModel()
                {
                    ReceiptSpecRecords = new List<ReceiptSpecRecord>() { new ReceiptSpecRecord() { NumPos = 1, GoodName = "Шляпа" }, new ReceiptSpecRecord() { NumPos = 2, GoodName = "Колбаса" } },
                    ReceiptNumber = 1,
                    Total = 100,
                    ShiftNumber = 3,
                    Cashier = "Кассир1",
                    PaymentType = 2,
                    AmountWithoutDiscount = 111,
                    Discount = 10
                    


                },
                InputValue = "123",
                Status = "вввод шк"
            })


            , User = AuthenticationContext.User };
    }
}