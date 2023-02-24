namespace Pos.Entities.Commands;

public abstract class NumericCommand: AbstractCommand
{
    public override string? Body
    {
        get => base.Body; set
        {
            if (!decimal.TryParse(value, out var _)) 
            {
                throw new Exception($"Incorrect number {value}");
            }
            base.Body = value;
        }
    }
}
