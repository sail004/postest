using Pos.BL.Interfaces;
using Pos.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.BL.Implementation
{
    public class AuthenticationContext : IAuthenticationContext
    {
        public User User { get; set; }
    }
}
