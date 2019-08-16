using Core.Shared.Configuration;

namespace Core.Infrastructure.Interfaces.Account
{
    public interface IAccountProvider
    {
        Configuration Configuration { get; set; }

        LoginResult Login(LoginInfo login);

        LoginResult Logout();

        string GetLoginCookie();

        LoginResult Register(RegisterInfo user);
    }
}
