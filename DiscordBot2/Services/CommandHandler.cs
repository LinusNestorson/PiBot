using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2.Services
{
    public class CommandHandler
    {
        public static IServiceProvider Provider;
        public static DiscordSocketClient Discord;
        public static CommandService Commands;
        public static IConfigurationRoot Config;

        public CommandHandler(DiscordSocketClient discord, CommandService commands, IConfigurationRoot config, IServiceProvider provider)
        {
            Provider = provider;
            Config = config;
            Discord = discord;
            Commands = commands;

            Discord.Ready += OnReady;
            Discord.MessageReceived += OnMessageReceived;
        }

        private async Task OnMessageReceived(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message.Author.IsBot) return; 
            var context = new SocketCommandContext(Discord, message);
            int pos = 0;
            if (message.HasCharPrefix('!', ref pos))// Kanske behöver byta till HasStringPrefix och referra till _config
            {
                var result = await Commands.ExecuteAsync(context, pos, Provider);
                if (!result.IsSuccess)
                {
                    var reason = result.Error;
                    await context.Channel.SendMessageAsync($"The following error occured: \n {reason}");
                    Console.WriteLine(reason);
                }
            }
        }       

        private Task OnReady()
        {
            Console.WriteLine($"Connected as {Discord.CurrentUser.Username}#{Discord.CurrentUser.Discriminator}");
            return Task.CompletedTask;
        }
    }
}

