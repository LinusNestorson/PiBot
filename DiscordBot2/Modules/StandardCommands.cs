using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2.Modules
{
    public class StandardCommands : ModuleBase
    {
        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("Pong!");
        }
        [Command("Du är bäst Bosse")]
        public async Task SignOfLove()
        {
            await Context.Channel.SendMessageAsync($"Nej du är bäst {Context.User}");
        }
        [Command("Banan")]
        public async Task Banana()
        {
            await Context.Channel.SendMessageAsync($"Enligt säkra källor är bananen ondskefull, oskyldig, unken och söt.");
        }
        [Command("constructor")]
        public async Task Constructor()
        {
            await Context.Channel.SendMessageAsync($"ctor + tab + tab");
        }
        [Command("info")]
        public async Task Info()
        {
            var builder = new EmbedBuilder()
                .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                .WithDescription($"Här har du lite info om dig {Context.User} <3")
                .WithColor(new Color(33, 176, 252))
                .AddField($"Joined {Context.Guild.Name} at", (Context.User as SocketGuildUser).JoinedAt.Value.ToString("dd/MM/yyyy") , true)
                .WithCurrentTimestamp();
            var embed = builder.Build();
            await Context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
