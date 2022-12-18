using Pos.BL.Interfaces;
using Pos.Entities.User;

namespace Pos.BL.Implementation;

public class AuthenticationContext : IAuthenticationContext
{
    public User User { get; set; }
}