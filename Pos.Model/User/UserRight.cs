namespace Pos.Entities.User;

public record UserRight : DataEntity
{
    public int IdUser { get; set; }
    public int IdAction { get; set; }
}