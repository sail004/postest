﻿using DataAccess.Interfaces;
using Pos.Entities.User;

namespace DataAccess.Implementation;

internal class UserRepository : IUserRepository
{
    private readonly List<User> _testModel = new()
    {
        new User
        {
            Id = 1, Name = "Администратор", UserRole = new UserRole { Id = 1, NameRole = "Администратор" },
            Password = "1"
        },
        new User { Id = 2, Name = "Кассир", UserRole = new UserRole { Id = 2, NameRole = "Кассир" }, Password = "3" }
    };

    public User GetByPassword(string password)
    {
        return _testModel.FirstOrDefault(user => user.Password == password);
    }

    public Task<IEnumerable<User>> ReadAllAsync()
    {
        throw new NotImplementedException();
    }

    public User ReadById(int id)
    {
        throw new NotImplementedException();
    }
}