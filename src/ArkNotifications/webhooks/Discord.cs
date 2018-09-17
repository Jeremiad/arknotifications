using System;
using System.Net.Http;
using Newtonsoft.Json;
using Serilog;

namespace ArkNotifications
{
    public class Discord
    {
        public static async void SendNotification(string noTitle, string steamId)
        {
            try
            {
                DiscordMessageModel messageModel = new DiscordMessageModel() { content = noTitle, };

                string str = JsonConvert.SerializeObject(messageModel);

                var content = new StringContent(str, System.Text.Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();

                await client.PostAsync(messageModel.webHookUrl, content);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Discord post error:");
            }
        }
    }
}
