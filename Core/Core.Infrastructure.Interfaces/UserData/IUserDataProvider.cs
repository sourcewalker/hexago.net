using Core.Shared.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure.Interfaces.UserData
{
    public interface IUserDataProvider
    {
        Configuration Configuration { get; set; }

        User GetUserDetails<T>(T id);

        void CreateUser(User user);

        void UpdateUserDetails(User user);

        void DeleteUser<T>(T id);
    }
}
