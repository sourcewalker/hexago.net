using Core.Shared.Configuration;
using Core.Infrastructure.Interfaces.Account;
using Core.Infrastructure.Interfaces.UserData;
using System;

namespace Infrastructure.Community
{
    public class CommunityProvider : IAccountProvider
    {
        public Configuration Configuration
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public LoginResult ChangePassword(Login login)
        {
            throw new NotImplementedException();
        }

        public LoginResult Login(Login login)
        {
            throw new NotImplementedException();
        }

        public LoginResult Register(Login login, User user)
        {
            throw new NotImplementedException();
        }
    }
}
