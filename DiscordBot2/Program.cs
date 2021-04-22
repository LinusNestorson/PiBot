using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace DiscordBot2
{
    class Program
    {
        // Program entry point
        //static void Main(string[] args)
        public static async Task Main(string[] args)
            => await Startup.RunAsync(args);
    }
}
