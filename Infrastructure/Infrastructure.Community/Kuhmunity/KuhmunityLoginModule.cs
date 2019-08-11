using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using Web.Service.Models;
using SWEET.WebProjects.Brands.Milka.Kuhmunity.DTO;
using Web.Service.Kuhmunity.Interface;
using Web.Service.Kuhmunity.Models;
using Web.Service.Kuhmunity.Utility;

namespace Web.Service.Kuhmunity
{
    public class KuhmunityLoginModule : KuhmunityBase, IResponseBase
    {
        public string CampaignID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IsPersistentCookie { get; set; }
        public string Locale { get; set; }
        public string SessionTicket { get; set; }

        private UserDetailDTO UserDetail;


        public Response GetResponse()
        {
            Response response = new Response
            {
                IsSuccessful = false
            };

            var KuhmunityViewModel = new
            {
                CampaignID,
                Email,
                Password,
                IsPersistentCookie
            };

            using (var client = new WebClient())
            {
                try
                {
                    var data = JsonConvert.SerializeObject(KuhmunityViewModel);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    var apiResponse = client.UploadString(new Uri(GetKuhmunityApiEndpoint() + "Login?output=json"), "POST", data);

                    if (!String.IsNullOrWhiteSpace(apiResponse))
                    {
                        var receivedData = JsonConvert.DeserializeObject<UserLoginResultDTO>(apiResponse);
                        if (receivedData.Status.Equals("OK"))
                        {
                            response.IsSuccessful = true;
                            response.Body = receivedData.UserDetailDTO;
                            UserDetail = receivedData.UserDetailDTO;
                            SessionTicket = receivedData.SessionTicket;
                        }
                        else
                        {
                            response.Message = receivedData.Status;
                        }
                    }

                    return response;
                }
                catch (Exception ex)
                {
                    response.Message = ResponseMessages.SERVER_ERROR;
                    response.ErrorMessage = ex.Message;

                    return response;
                }
            }
        }

        public string GetLoginCookie()
        {
            return new KuhmunityCookie
            {
                SessionTicket = this.SessionTicket,
                SessionUserName = UserDetail.Nickname,
                SessionProfilePicture = UserDetail.ProfilePictureUrl,
                SessionBackgroundUrl = UserDetail.BackGroundUrl
            }.ToString();
        }
    }
}