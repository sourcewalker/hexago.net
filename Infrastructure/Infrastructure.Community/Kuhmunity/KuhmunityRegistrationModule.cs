using System;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SWEET.WebProjects.Brands.Milka.Kuhmunity.DTO;
using Web.Service.Kuhmunity.Interface;
using Web.Service.Kuhmunity.Models;
using Web.Service.Kuhmunity.Utility;
using Web.Configuration.Interfaces;

namespace Web.Service.Kuhmunity
{
    public class KuhmunityRegistrationModule : KuhmunityBase, IResponseBase
    {
        UserRegisterInput KuhmunityProfileData;
        public KuhmunityRegistrationModule(UserRegisterInput kuhmunityData)
        {
            KuhmunityProfileData = kuhmunityData;
        }

        public Response GetResponse()
        {
            Response response = new Response
            {
                IsSuccessful = false
            };

            using (var client = new WebClient())
            {
                try
                {
                    var data = JsonConvert.SerializeObject(KuhmunityProfileData);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    var apiResponse = client.UploadString(new Uri(GetKuhmunityApiEndpoint() + "Register?output=json"), "POST", data);

                    if (!String.IsNullOrWhiteSpace(apiResponse))
                    {
                        var receivedData = JsonConvert.DeserializeObject<UserResultDTO>(apiResponse);
                        if (receivedData.Status.Equals("OK"))
                        {
                            response.IsSuccessful = true;
                            response.Body = receivedData.UserId;
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
    }
}