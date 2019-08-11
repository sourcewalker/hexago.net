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
    public class KuhmunityProfileModule : KuhmunityBase, IResponseBase
    {
        UserOperationInput UserOperationData;

        public KuhmunityProfileModule(UserOperationInput operationData)
        {
            UserOperationData = operationData;
            operationData.UserId = GetUserIdFromSessionTicket(operationData.SessionTicket);
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
                    var data = JsonConvert.SerializeObject(UserOperationData);
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    var apiResponse = client.UploadString(new Uri(GetKuhmunityApiEndpoint() + "GetUserProfile?output=json"), "POST", data);
                    
                    if (!String.IsNullOrWhiteSpace(apiResponse))
                    {
                        var receivedData = JsonConvert.DeserializeObject<GetUserDetailResultDTO>(apiResponse);
                        if (receivedData.Status.Equals("OK")) {
                            response.IsSuccessful = true;
                            response.Body = receivedData.UserDetail;
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