using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2.Database
{
    class BotContext : DbContext
    {
        private const string DatabaseName = "SQLiteDB_PiBot";

        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server = .\SQLite;Database={DatabaseName};trusted_connection=true");
        }
    }

}
