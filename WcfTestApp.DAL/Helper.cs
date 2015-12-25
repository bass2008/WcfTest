using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfTestApp.Domain.Interfaces;
using WcfTestApp.Domain.Models;

namespace WcfTestApp.DAL
{
    public class Helper
    {
        private ILoger _loger;

        public Helper(ILoger loger)
        {
            _loger = loger;
        }

        public void Start()
        {
            using (var db = new ServiceContext())
            {
                // создаем два объекта User
                var user1 = new User { Name = "Tom" };
                var user2 = new User { Name = "Sam" };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                _loger.Write("Объекты успешно сохранены ");

                // получаем объекты из бд и выводим на консоль
                var users = db.Users;
                _loger.Write("Список объектов: ");
                foreach (var u in users)
                {
                    _loger.Write(String.Format("{0}:{1}", u.UserId, u.Name));
                }
            }
        }
    }
}
