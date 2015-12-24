using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfTestApp.DAL.Models;

namespace WcfTestApp.DAL
{
    class ContextInitializer : DropCreateDatabaseAlways<ServiceContext>
    {
        protected override void Seed(ServiceContext db)
        {
            var user1 = new User { Name = "Samsung Galaxy S5" };
            var user2 = new User { Name = "Nokia Lumia 630" };

            db.Users.Add(user1);
            db.Users.Add(user2);
            db.SaveChanges();
        }
    }
}
