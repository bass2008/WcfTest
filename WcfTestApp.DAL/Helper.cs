using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfTestApp.DAL
{
    public class Helper
    {
        public string Start()
        {
            var res = "";
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Sam", Age = 26 };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                res += "Объекты успешно сохранены ";

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                res += "Список объектов: ";
                foreach (User u in users)
                {
                    res += String.Format("{0}.{1} - {2} ", u.Id, u.Name, u.Age);
                }
            }
            return res;
        }
    }
}
