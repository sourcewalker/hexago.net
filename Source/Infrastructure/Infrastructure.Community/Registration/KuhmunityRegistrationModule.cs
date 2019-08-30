using Infrastructure.Community.Helper;
using Infrastructure.Community.Interfaces;
using Infrastructure.Community.Models;
using SWEET.WebProjects.Brands.Milka.Kuhmunity.DTO;

namespace Infrastructure.Community.Registration
{
    public class KuhmunityRegistrationModule : KuhmunityBase, IRegistrationProvider
    {
        UserRegisterInput _kuhmunityProfileData;

        public KuhmunityRegistrationModule(UserRegisterInput kuhmunityData)
        {
            _kuhmunityProfileData = kuhmunityData;
        }

        public KuhmunityResponse Register()
        {
            return KuhmunityRegistrationHelper.Register(GetKuhmunityApiEndpoint(), _kuhmunityProfileData);
        }
    }
}