using HeBianGu.General.Data.Interface;
using HeBianGu.General.WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.App.Demo.WcfServer
{
    class Program
    {
        static void Main(string[] args)
        {

            IServerService service = new TcpService("127.0.0.1", "7777");

            //IServerService service = new TcpService("127.0.0.1", "7777");

            //IServerService service = new MsmqService();

            service.Register<IData, Data>();

            service.Register<IMyContract, MyContract>();

            Console.WriteLine("启动成功");

            Console.Read();
        }
    }
}
