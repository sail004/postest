namespace Pos.Entities.User;

public record UserRole : DataEntity
{
    public int Id { get; set; }
    public string NameRole { get; set; }
}