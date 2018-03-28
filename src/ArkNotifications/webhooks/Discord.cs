using System;
using System.Net.Http;
using ArkNotifications.Models;
using Newtonsoft.Json;

namespace ArkNotifications
{
	public class Discord
	{
		public static async void SendNotification(string noTitle, string steamId)
		{
			DiscordMessageModel messageModel = new DiscordMessageModel() { content = noTitle, };

			string str = JsonConvert.SerializeObject(messageModel);

			var content = new StringContent(str, System.Text.Encoding.UTF8, "application/json");

			HttpClient client = new HttpClient();
			await client.PostAsync(messageModel.webHookUrl, content);
		}
	}
}
