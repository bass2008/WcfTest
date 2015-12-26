using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WcfTestApp.Domain.Interfaces;

namespace WcfTestApp.WcfService
{
    public class Service : IService
    {
        public string EchoWithGet(string s)
        {
            return "You said " + s;
        }

        public string EchoWithPost(string s)
        {
            return "You said " + s;
        }
    }
}
