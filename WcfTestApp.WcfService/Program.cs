using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using WcfTestApp.Domain.Interfaces;
using WcfTestApp.WcfContracts;

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
