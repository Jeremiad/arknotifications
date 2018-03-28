using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ArkNotifications
{
	public class DiscordMessageModel
	{
		private static IConfigurationRoot Configuration { get; set; }

		public DiscordMessageModel()
		{
			var builder = new ConfigurationBuilder()
			 .SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json");

			Configuration = builder.Build();
		}


		public string webHookUrl { get
			{
				return Configuration["Webhooks:Discord:webhook_url"];
			} }
		public string content { get; set; }
		public string username { get 
			{
				return Configuration["Webhooks:Discord:username"];
			} }
		public string avatar_url { get; set; }
		public bool tts { get; set; }
		public byte[] file { get; set; }
		public string embeds { get; set; }


	}
}
