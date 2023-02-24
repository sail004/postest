namespace Pos.Entities.Commands;

public class PriceChangingCommand : NumericCommand
{
	public PriceChangingCommand(string payload)
	{
		Body = payload;
	}
    public override CommandLabel CommandLabel => CommandLabel.PriceChanged;
}

