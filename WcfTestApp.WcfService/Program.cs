using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WcfTestApp.Domain.Interfaces;

namespace WcfTestApp.WcfService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = new WebServiceHost(typeof (Service), new Uri("http://localhost:8000/"));
                var ep = host.AddServiceEndpoint(typeof (IService), new WebHttpBinding(), "");
                host.Open();
                Console.WriteLine("Сервис запущен!");
                Console.WriteLine("Нажмите любую клавишу для выхода...");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("     Ошибка: {0}", ex.Message);
                Console.WriteLine("     Нажмите любую клавишу для выхода...");
                Console.ReadLine();
            }
        }
    }
}
