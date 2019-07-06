using Core.Infrastructure.Interfaces.Logging;
using System;
using Core.Service.Captcha;
using Core.Shared.Utility;
using Core.DAL.Interfaces;
using Core.Service.Interfaces;

namespace Core.Service.Flow
{
    public class ValidationService : IValidationService
    {
        private readonly IParticipationRepository _participationRepository;
        private readonly ILoggingProvider _logger;

        public ValidationService(
            ILoggingProvider logger, 
            IParticipationRepository participationRepository)
        {
            _logger = logger;
            _participationRepository = participationRepository;
        }

        public bool ValidateCaptcha(string captchaResponse)
        {
            if (captchaResponse == null)
                return false;

            var response = false;
            try
            {
                return GoogleRecaptchaHelper.ValidateReCaptchaV2(captchaResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Captcha validation failed", ex);
            }
            return response;
        }

        public bool HasAlreadyParticipated(string email)
        {
            var emailHash = StringUtility.Md5HashEncode(email.ToLower());
            return _participationRepository.GetByEmailHash(emailHash) != null;
        }
    }
}
