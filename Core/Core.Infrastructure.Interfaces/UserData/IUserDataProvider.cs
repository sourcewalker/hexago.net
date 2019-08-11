using Core.Shared.Configuration;

namespace Core.Infrastructure.Interfaces.UserData
{
    public interface IUserDataProvider
    {
        Configuration Configuration { get; set; }

        User GetUserDetails<T>(T id);
    }
}
