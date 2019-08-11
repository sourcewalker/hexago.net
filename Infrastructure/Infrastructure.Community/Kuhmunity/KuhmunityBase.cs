using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Web.Configuration.Interfaces;

namespace Web.Service.Kuhmunity
{
    public abstract class KuhmunityBase
    {
        //protected const string KUHMUNITY_ENDPOINT = "http://stg-service.kuhmunity.milka.com/services/UserService/";
        //protected const string KUHMUNITY_ENDPOINT = "https://service-kuhmunity.milka.com/services/UserService/";

        protected string GetUserIdFromSessionTicket(string sessionTicket)
        {
            string[] components = sessionTicket.Split('|');
            string sessionToken = components[0];
            string userId = components[1];
            string persistentTicket = components[2];
            string dataHash = components[3];

            return userId;
        }

        protected string GetKuhmunityApiEndpoint()
        {
            return ConfigurationManager.AppSettings["KuhmunityApiEndpoint"];
            //return _configProvider.GetSharedConfig("KuhmunityApiEndpoint");
        }

        public static Dictionary<string, string> ExtractCookieData(string cookieValue)
        {
            //string cookieValue = "SessionTicket=214f3aa2-ebe5-4db7-8167-8169b9975a1b|47e5ba65-aacd-429f-bee2-3c4cf43f6a15|true|cdbeef6a858f42bfa84d2b37ae8a7c57e1ea4481387c674d&SessionUserName=arvind-d&SessionProfilePicture=http://f467c9e2e7dab99b1982-57eac52fa57d48c2a6011f43b4fe6b7e.r38.cf3.rackcdn.com/profilepicturecropped_d3ca570c-89ce-4b9a-a479-dabea057a506.png&SessionBackgroundUrl=http://f467c9e2e7dab99b1982-57eac52fa57d48c2a6011f43b4fe6b7e.r38.cf3.rackcdn.com/background_f34c220e-a295-42ff-9714-6b4ca8b450c0.png";
            var cookieItems = new Dictionary<string, string>();
            var components = cookieValue.Split('&');
            foreach (string item in components)
            {
                var itemParts = item.Split('=');
                cookieItems.Add(itemParts[0], itemParts[1]);
            }

            return cookieItems;
        }

        public static string DecryptConsumerId(string encryptedConsumerId)
        {
            string decrypted;

            var keyBytes = Encoding.ASCII.GetBytes("$w33tCtx");
            byte[] bytesToDecrypt;
            try
            {
                var decodedCryptedData = HttpUtility.UrlDecode(encryptedConsumerId);
                if (!string.IsNullOrEmpty(decodedCryptedData))
                {
                    bytesToDecrypt = Convert.FromBase64String(decodedCryptedData);
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {

                bytesToDecrypt = Convert.FromBase64String(encryptedConsumerId);
            }

            using (var cryptoProvider = new DESCryptoServiceProvider())
            {
                using (var memoryStream = new MemoryStream(bytesToDecrypt))
                {
                    using (
                        var cryptoStream = new CryptoStream(
                            memoryStream,
                            cryptoProvider.CreateDecryptor(keyBytes, keyBytes),
                            CryptoStreamMode.Read))
                    {
                        using (var reader = new StreamReader(cryptoStream))
                        {
                            decrypted = reader.ReadToEnd();
                        }
                    }
                }
            }
            return decrypted;
        }

    }
}