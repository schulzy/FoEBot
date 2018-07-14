
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.Interface;
using Unity;

namespace Schulzy.FoEBot.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            UnityContainer container = new UnityContainer();
            container.RegisterType<IHttpRequestManager, HttpRequestManager>();

        }
    }
}
