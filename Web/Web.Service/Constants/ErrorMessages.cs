﻿
namespace Web.Service.Constants
{
    public struct ErrorMessages
    {
        public struct Vote
        {

            public const string EmailRequired = "EMAIL_REQUIRED";

            public const string EmailInvalid = "EMAIL_INVALID";

            public const string AlreadyUsedEmail = "EMAIL_ALREADY_USED";

            public const string TermsRequired = "TERMS_CONSENT_REQUIRED";

            public const string CaptchaInvalid = "CAPTCHA_INVALID";
        }
    }
}