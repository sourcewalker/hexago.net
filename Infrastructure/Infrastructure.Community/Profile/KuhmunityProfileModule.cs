using Infrastructure.Community.Helper;
using Infrastructure.Community.Interfaces;
using Infrastructure.Community.Models;
using SWEET.WebProjects.Brands.Milka.Kuhmunity.DTO;

namespace Infrastructure.Community.Profile
{
    public class KuhmunityProfileModule : KuhmunityBase, IProfileProvider
    {
        UserOperationInput _userOperationData;

        public KuhmunityProfileModule(UserOperationInput operationData)
        {
            _userOperationData = operationData;
            operationData.UserId = GetUserIdFromSessionTicket(operationData.SessionTicket);
        }

        public KuhmunityResponse GetProfile()
        {
            return KuhmunityProfileHelper.GetProfile(GetKuhmunityApiEndpoint(), _userOperationData);
        }
    }
}