using Core.Infrastructure.Interfaces.Validator;
using Infrastructure.Captcha.Helper;

namespace Infrastructure.Captcha.Provider
{
    public class CaptchaProvider : IFormValidatorProvider
    {
        public bool Validate(string response)
        {
            return GoogleRecaptchaHelper.ValidateReCaptchaV2(response);
        }
    }
}
