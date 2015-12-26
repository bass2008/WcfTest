using System.Data.Entity;
using WcfTestApp.Domain.Models;

namespace WcfTestApp.DAL
{
    class ContextInitializer : DropCreateDatabaseAlways<ServiceContext>
    {
        protected override void Seed(ServiceContext db)
        {
            var user1 = new User { Name = "Иванов И.", Email = "ya@ya.ru" };
            var user2 = new User { Name = "Петров П.", Email = "g@g.com" };

            var event1 = new Event { Name = "php" };
            var event2 = new Event { Name = "csharp" };
            var event3 = new Event { Name = "all" };

            var channel1 = new Channel { Name = "E-mail" };
            var channel2 = new Channel { Name = "SMS" };

            var importance1 = new Importance { Name = "Low" };
            var importance2 = new Importance { Name = "Middle" };
            var importance3 = new Importance { Name = "Critical" };

            importance1.Channels.Add(channel1);
            importance2.Channels.Add(channel2);
            importance3.Channels.Add(channel1);
            importance3.Channels.Add(channel2);

            db.Users.Add(user1);
            db.Users.Add(user2);

            db.Events.Add(event1);
            db.Events.Add(event2);
            db.Events.Add(event3);

            db.Channels.Add(channel1);
            db.Channels.Add(channel2);

            db.Importances.Add(importance1);
            db.Importances.Add(importance2);
            db.Importances.Add(importance3);

            user1.Events.Add(event1);
            user1.Events.Add(event3);
            user2.Events.Add(event2);
            user2.Events.Add(event3);

            db.SaveChanges();
        }
    }
}
