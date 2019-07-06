using System.ComponentModel.DataAnnotations;
using Web.Service.Constants;
using Web.Service.Validation;

namespace Web.Service.Models
{
    public class ParticipationViewModel
    {
        [Required(ErrorMessage = ErrorMessages.Vote.EmailRequired)]
        [EmailAddress(ErrorMessage = ErrorMessages.Vote.EmailInvalid)]
        [NotUsedEmail(ErrorMessage = ErrorMessages.Vote.AlreadyUsedEmail)]
        public string Email { get; set; }

        public string Culture { get; set; }

        public bool RetailerConsent { get; set; }

        public bool NewsletterOptin { get; set; }

        [Captcha(ErrorMessage = ErrorMessages.Vote.CaptchaInvalid)]
        public string Captcha { get; set; }
    }
}