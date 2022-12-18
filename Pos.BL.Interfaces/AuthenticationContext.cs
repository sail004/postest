using System.Diagnostics.CodeAnalysis;
using Pos.Entities.User;

namespace Pos.BL.Interfaces;

public interface IAuthenticationContext
{
    User User { get; set; }
}