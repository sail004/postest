namespace Pos.Entities.User
{
    public record User:DataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRole UserRole { get; set; }
        public string Password { get; set; }
    }

}
