using Core.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infrastructure.Interfaces.UserData;

namespace Core.Infrastructure.Interfaces.Account
{
    public interface IAccountProvider
    {
        Configuration Configuration { get; set; }

        LoginResult Login(Login login);

        LoginResult Register(Login login, User user);

        LoginResult ChangePassword(Login login);
    }
}
