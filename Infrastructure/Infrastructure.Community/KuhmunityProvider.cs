using Core.Shared.Configuration;
using Core.Infrastructure.Interfaces.UserData;
using System;
using Core.Infrastructure.Interfaces.Account;
using Infrastructure.Community.Login;

namespace Infrastructure.Community
{
    public class KuhmunityProvider : IAccountProvider, IUserDataProvider
    {
        public Configuration Configuration
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public string GetLoginCookie()
        {
            throw new NotImplementedException();
        }

        public User GetUserDetails<T>(T id)
        {
            throw new NotImplementedException();
        }

        public LoginResult Login(LoginInfo login)
        {
            var loginInfo = new KuhmunityLoginModule
            {
                Email = login.Username,
                Password = login.Password
            };

            var result = loginInfo.Login();
            return new LoginResult
            {
                Success = result.IsSuccessful,
                Message = result.Message
            };
        }

        public LoginResult Logout()
        {
            throw new NotImplementedException();
        }

        public LoginResult Register(RegisterInfo user)
        {
            throw new NotImplementedException();
        }
    }
}
