using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfTestApp.DAL.Models;

namespace WcfTestApp.DAL
{
    public class Helper
    {
        public string Start()
        {
            var res = "";
            using (var db = new ServiceContext())
            {
                // создаем два объекта User
                var user1 = new User { Name = "Tom" };
                var user2 = new User { Name = "Sam" };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                res += "Объекты успешно сохранены ";

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                res += "Список объектов: ";
                foreach (var u in users)
                {
                    res += String.Format("{0}:{1}", u.UserId, u.Name);
                }
            }
            return res;
        }
    }
}
