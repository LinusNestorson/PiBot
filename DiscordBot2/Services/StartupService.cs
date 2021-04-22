using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2.Services
{
    public class StartupService
    {
        public static IServiceProvider Provider;
        private readonly DiscordSocketClient Discord;
        private readonly CommandService Commands;
        private readonly IConfigurationRoot Config;

        public StartupService(IServiceProvider provider, DiscordSocketClient discord, CommandService commands, IConfigurationRoot config)
        {
            Provider = provider;
            Config = config;
            Discord = discord;
            Commands = commands;
        }

        public async Task StartAsync()
        {
            string token = Config["token"]; // Kan vara ett fel här. Testa då med en vanlig text-file istället istället för yml.
            if (string.IsNullOrEmpty(token))
            {
                Console.WriteLine("Please provide your Discord token in _config.yml");
                return;
            }

            await Discord.LoginAsync(TokenType.Bot, token);
            await Discord.StartAsync();
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Provider);
        }
    }
}
