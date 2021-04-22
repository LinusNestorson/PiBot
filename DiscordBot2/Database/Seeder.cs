using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot2.Database
{
    public static class Seeder
    {
        public static void FillUser(string name)
        {
            using (var db = new BotContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == name);
                if (user == null)
                {
                    user = new User { Name = name };
                    db.Update(user);
                    db.SaveChanges();
                }
            }
        }
    }
}
