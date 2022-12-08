﻿namespace Pos.Entities.User
{
    public record UserAction:DataEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActionLabel { get; set; }
    }

}
