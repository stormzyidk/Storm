using System;
using System.Diagnostics;
using System.Threading;
using RestSharp;

namespace Stormzy_launcher.Epic
{
	// Token: 0x0200000E RID: 14
	internal class Auth
	{
		// Token: 0x0600006D RID: 109 RVA: 0x000043D4 File Offset: 0x000025D4
		public static string GetDevicecodetoken()
		{
			RestClient restClient = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/token");
			RestRequest restRequest = new RestRequest(1);
			restRequest.AddHeader("Authorization", "Basic NTIyOWRjZDNhYzM4NDUyMDhiNDk2NjQ5MDkyZjI1MWI6ZTNiZDJkM2UtYmY4Yy00ODU3LTllN2QtZjNkOTQ3ZDIyMGM3");
			restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			restRequest.AddParameter("grant_type", "client_credentials");
			RestRequest restRequest2 = restRequest;
			string[] array = restClient.Execute(restRequest2).Content.Split(new char[]
			{
				':'
			}, 26);
			string result;
			try
			{
				result = array[1].ToString().Split(new char[]
				{
					','
				}, 2)[0].ToString().Split(new char[]
				{
					'"'
				}, 2)[1].ToString().Split(new char[]
				{
					'"'
				}, 2)[0].ToString();
			}
			catch
			{
				MessageBox.Show("Bitte stelle sicher das du mit dem Internet verbunden bist und versuche es erneut!\nDer Launcher schließt sich jetzt selber.");
				Process.GetCurrentProcess().Kill();
				result = "error";
			}
			return result;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000044C8 File Offset: 0x000026C8
		public static string GetDevicecode(string auth)
		{
			RestClient restClient = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/deviceAuthorization");
			RestRequest restRequest = new RestRequest(1);
			restRequest.AddHeader("Authorization", "Bearer " + auth);
			restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			RestRequest restRequest2 = restRequest;
			string[] array = restClient.Execute(restRequest2).Content.Split(new char[]
			{
				','
			}, 8);
			string[] array2 = array[3].ToString().Split(new char[]
			{
				'"'
			}, 4)[3].ToString().Split(new char[]
			{
				'"'
			}, 2);
			string[] array3 = array[1].ToString().Split(new char[]
			{
				'"'
			}, 4)[3].ToString().Split(new char[]
			{
				'"'
			}, 2);
			Process.Start(array2[0]);
			string content;
			for (; ; )
			{
				RestClient restClient2 = new RestClient("https://account-public-service-prod03.ol.epicgames.com/account/api/oauth/token");
				RestRequest restRequest3 = new RestRequest(1);
				restRequest3.AddHeader("Authorization", "Basic NTIyOWRjZDNhYzM4NDUyMDhiNDk2NjQ5MDkyZjI1MWI6ZTNiZDJkM2UtYmY4Yy00ODU3LTllN2QtZjNkOTQ3ZDIyMGM3");
				restRequest3.AddHeader("Content-Type", "application/x-www-form-urlencoded");
				restRequest3.AddParameter("grant_type", "device_code");
				restRequest3.AddParameter("device_code", array3[0].ToString());
				RestRequest restRequest4 = restRequest3;
				content = restClient2.Execute(restRequest4).Content;
				if (content.Contains("access_token"))
				{
					break;
				}
				content.Contains("errors.com.epicgames.not_found");
				Thread.Sleep(150);
			}
			string[] array4 = content.Split(new char[]
			{
				':'
			}, 26);
			return array4[1].ToString().Split(new char[]
			{
				','
			}, 2)[0].ToString().Split(new char[]
			{
				'"'
			}, 2)[1].ToString().Split(new char[]
			{
				'"'
			}, 2)[0].ToString() + "," + array4[16].ToString().Split(new char[]
			{
				','
			}, 2)[0];
		}

		// Token: 0x0600006F RID: 111 RVA: 0x000046B8 File Offset: 0x000028B8
		public static string GetToken(string authCode)
		{
			Console.WriteLine("Token wird angefragt");
			RestClient restClient = new RestClient("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/token");
			RestRequest restRequest = new RestRequest(1);
			restRequest.AddHeader("Authorization", "basic ZWM2ODRiOGM2ODdmNDc5ZmFkZWEzY2IyYWQ4M2Y1YzY6ZTFmMzFjMjExZjI4NDEzMTg2MjYyZDM3YTEzZmM4NGQ=");
			restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			restRequest.AddParameter("grant_type", "authorization_code");
			restRequest.AddParameter("code", authCode);
			RestRequest restRequest2 = restRequest;
			string content = restClient.Execute(restRequest2).Content;
			if (content.Contains("access_token"))
			{
				string[] array = content.Split(new char[]
				{
					':'
				}, 26);
				string str = array[17].ToString().Split(new char[]
				{
					','
				}, 2)[0];
				return array[1].ToString().Split(new char[]
				{
					','
				}, 2)[0].ToString().Split(new char[]
				{
					'"'
				}, 2)[1].ToString().Split(new char[]
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

		// Token: 0x06000070 RID: 112 RVA: 0x00004800 File Offset: 0x00002A00
		public static string GetExchange(string token)
		{
			RestClient restClient = new RestClient("https://account-public-service-prod.ol.epicgames.com/account/api/oauth/exchange");
			RestRequest restRequest = new RestRequest(0);
			restRequest.AddHeader("Authorization", "bearer " + token);
			RestRequest restRequest2 = restRequest;
			string content = restClient.Execute(restRequest2).Content;
			Console.WriteLine(content);
			if (content.Contains("errors.com.epicgames.common.oauth.invalid_token"))
			{
				return "error";
			}
			return content.Split(new char[]
			{
				','
			}, 4)[1].ToString().Split(new char[]
			{
				','
			}, 2)[0].ToString().Split(new char[]
			{
				'"'
			}, 2)[1].ToString().Split(new char[]
			{
				'"'
			}, 2)[1].ToString().Split(new char[]
			{
				'"'
			}, 2)[1].ToString().Split(new char[]
			{
				'"'
			}, 2)[0].ToString();
		}
	}
}