namespace Pos.Entities.User
{
    public record Command:DataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CommandLabel { get; set; }
    }

}
