using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Service.Kuhmunity.Interface;
using Web.Service.Kuhmunity.Models;
using Web.Service.Kuhmunity.Utility;

namespace Web.Service.Kuhmunity.Validation
{
    public class KuhmunityInputValidationModule : IResponseBase
    {
        public string Nickname { get; set; }
        public string Password { get; set; }
        public string PasswordReconfirm { get; set; }
        public bool TermsAccepted { get; set; }
        public bool PrivacyAccepted { get; set; }

        public Response GetResponse()
        {
            Response response = new Response
            {
                IsSuccessful = false
            };

            if (String.IsNullOrWhiteSpace(Nickname))
            {
                response.Message = ResponseMessages.MISSING_NICKNAME;

                return response;
            }

            if (!TermsAccepted)
            {
                response.Message = ResponseMessages.KUHMUNITY_TERMS_NOT_ACCEPTED;

                return response;
            }

            if (!PrivacyAccepted)
            {
                response.Message = ResponseMessages.KUHMUNITY_PRIVACY_NOT_ACCEPTED;

                return response;
            }

            if (String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(PasswordReconfirm))
            {
                response.Message = ResponseMessages.MISSING_PASSWORD;

                return response;
            }

            if (!Password.Equals(PasswordReconfirm))
            {
                response.Message = ResponseMessages.PASSWORD_MISMATCH;

                return response;
            }

            response.IsSuccessful = true;
            response.Message = ResponseStatus.OK;

            return response;
        }
    }
}