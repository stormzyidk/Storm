using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using RestSharp;

namespace StormFN_Launcher.Epic
{
    internal class Auth
    {
        public static string GetDevicecodetoken()
        {
            RestClient restClient = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/token");
            RestRequest restRequest1 = new RestRequest(Method.POST);
            restRequest1.AddHeader("Authorization", "Basic YjA3MGYyMDcyOWY4NDY5M2I1ZDYyMWM5MDRmYzViYzI6SEdAWEUmVEdDeEVKc2dUIyZfcDJdPWFSbyN+Pj0+K2M2UGhSKXpYUA==");
            restRequest1.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            restRequest1.AddParameter("grant_type", (object)"client_credentials");
            RestRequest restRequest2 = restRequest1;
            string[] strArray = restClient.Execute((IRestRequest)restRequest2).Content.Split(new char[1]
            {
                ':'
            }, 26);
            try
            {
                return strArray[1].ToString().Split(new char[1]
                {
                    ','
                }, 2)[0].ToString().Split(new char[1] { '"' }, 2)[1].ToString().Split(new char[1]
                {
                    '"'
                }, 2)[0].ToString();
            }
            catch
            {
                MessageBox.Show("Please make sure that you are connected to the internet.");
                Process.GetCurrentProcess().Kill();
                return "error";
            }
        }

       

        public static string GetDevicecode(string auth)
        {
            RestClient restClient1 = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/deviceAuthorization");
            RestRequest restRequest1 = new RestRequest(Method.POST);
            restRequest1.AddHeader("Authorization", "Bearer " + auth);
            restRequest1.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            RestRequest restRequest2 = restRequest1;
            string[] strArray1 = restClient1.Execute((IRestRequest)restRequest2).Content.Split(new char[1]
            {
                ','
            }, 8);
            string[] strArray2 = strArray1[3].ToString().Split(new char[1]
            {
                '"'
            }, 4)[3].ToString().Split(new char[1] { '"' }, 2);
            string[] strArray3 = strArray1[1].ToString().Split(new char[1]
            {
                '"'
            }, 4)[3].ToString().Split(new char[1] { '"' }, 2);
            Process.Start(strArray2[0]);
            string content;
            while (true)
            {
                RestClient restClient2 = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/token");
                RestRequest restRequest3 = new RestRequest(Method.POST);
                restRequest3.AddHeader("Authorization", "Basic NTIyOWRjZDNhYzM4NDUyMDhiNDk2NjQ5MDkyZjI1MWI6ZTNiZDJkM2UtYmY4Yy00ODU3LTllN2QtZjNkOTQ3ZDIyMGM3");
                restRequest3.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                restRequest3.AddParameter("grant_type", (object)"device_code");
                restRequest3.AddParameter("device_code", (object)strArray3[0].ToString());
                RestRequest restRequest4 = restRequest3;
                content = restClient2.Execute((IRestRequest)restRequest4).Content;
                if (!content.Contains("access_token"))
                {
                    content.Contains("errors.com.epicgames.not_found");
                    Thread.Sleep(150);
                }
                else
                    break;
            }
            string[] strArray4 = content.Split(new char[1] { ':' }, 26);
            return strArray4[1].ToString().Split(new char[1]
            {
                ','
            }, 2)[0].ToString().Split(new char[1] { '"' }, 2)[1].ToString().Split(new char[1]
            {
                '"'
            }, 2)[0].ToString() + "," + strArray4[16].ToString().Split(new char[1]
            {
                ','
            }, 2)[0];
        }

        public static string GetToken(string authCode)
        {
            Console.WriteLine("Token wird angefragt");
            RestClient restClient = new RestClient("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/token");
            RestRequest restRequest1 = new RestRequest(Method.POST);
            restRequest1.AddHeader("Authorization", "basic ZWM2ODRiOGM2ODdmNDc5ZmFkZWEzY2IyYWQ4M2Y1YzY6ZTFmMzFjMjExZjI4NDEzMTg2MjYyZDM3YTEzZmM4NGQ=");
            restRequest1.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            restRequest1.AddParameter("grant_type", (object)"authorization_code");
            restRequest1.AddParameter("code", (object)authCode);
            RestRequest restRequest2 = restRequest1;
            string content = restClient.Execute((IRestRequest)restRequest2).Content;
            if (content.Contains("access_token"))
            {
                string[] strArray = content.Split(new char[1] { ':' }, 26);
                string str = strArray[17].ToString().Split(new char[1]
                {
                    ','
                }, 2)[0];
                return strArray[1].ToString().Split(new char[1]
                {
                    ','
                }, 2)[0].ToString().Split(new char[1] { '"' }, 2)[1].ToString().Split(new char[1]
                {
                    '"'
                }, 2)[0].ToString() + "," + str;
            }
            if (content.Contains("It is possible that it was no longer valid"))
            {
                MessageBox.Show("An Error occured, pls try again at a later point.");
                Process.Start("https://www.epicgames.com/id/logout?redirectUrl=https%3A//www.epicgames.com/id/login%3FredirectUrl%3Dhttps%253A%252F%252Fwww.epicgames.com%252Fid%252Fapi%252Fredirect%253FclientId%253D3446cd72694c4a4485d81b77adbb2141%2526responseType%253Dcode");
                return "error";
            }
            MessageBox.Show(content);
            return "error";
        }

        public static string GetExchange(string token)
        {
            RestClient restClient = new RestClient("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/exchange");
            RestRequest restRequest1 = new RestRequest(Method.GET);
            restRequest1.AddHeader("Authorization", "bearer " + token);
            RestRequest restRequest2 = restRequest1;
            string content = restClient.Execute((IRestRequest)restRequest2).Content;
            Console.WriteLine(content);
            return content.Split(new char[1] { ',' }, 4)[1].ToString().Split(new char[1]
            {
                ','
            }, 2)[0].ToString().Split(new char[1] { '"' }, 2)[1].ToString().Split(new char[1]
            {
                '"'
            }, 2)[1].ToString().Split(new char[1] { '"' }, 2)[1].ToString().Split(new char[1]
            {
                '"'
            }, 2)[0].ToString();

            
        }
    }
}

