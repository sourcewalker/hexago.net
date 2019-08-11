using Core.Infrastructure.Interfaces.UserData;
using Core.Shared.Configuration;

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
