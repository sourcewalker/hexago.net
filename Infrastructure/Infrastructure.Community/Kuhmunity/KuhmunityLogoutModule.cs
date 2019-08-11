using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using SWEET.WebProjects.Brands.Milka.Kuhmunity.DTO;
using Web.Service.Kuhmunity.Interface;
using Web.Service.Kuhmunity.Models;
using Web.Service.Kuhmunity.Utility;

namespace Web.Service.Kuhmunity
{
    public class KuhmunityLogoutModule : KuhmunityBase, IResponseBase
    {
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
                    var logoutData = new UserLogoutInput();
                    var data = JsonConvert.SerializeObject(logoutData);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    var apiResponse = client.UploadString(new Uri(GetKuhmunityApiEndpoint() + "Logout?output=json"), "POST", data);

                    if (!String.IsNullOrWhiteSpace(apiResponse))
                    {
                        var receivedData = JsonConvert.DeserializeObject<UserOperationResultDTO>(apiResponse);
                        if (receivedData.Status.Equals("OK"))
                        {
                            response.IsSuccessful = true;
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