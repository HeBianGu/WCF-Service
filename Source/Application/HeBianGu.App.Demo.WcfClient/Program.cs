using HeBianGu.General.Data;
using HeBianGu.General.Data.Interface;
using HeBianGu.General.WcfService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.App.Demo.WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {

            IClientService service = new TcpService("127.0.0.1", "7777");


            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        Thread.Sleep(10);

            //        //service.Do<IData>(l => l.Do()); 

            //        var result = service.DuplexCall<IMyContract, CallResult, IMessageCallBack>(l => l.Do(), callBack);

            //        Console.WriteLine(result?.Code);
            //        Console.WriteLine(result?.Message);
            //    }
            //});



            //  Do ：说明
            //Task.Run(async()=>
            //{
            //    while(true)
            //    {

            //            var result = await service.CallAsync<IData, CallResult<TestModel>>(l => l.GetTestModelByID("111"));

            //            if (result != null)
            //            {
            //                Console.WriteLine(result.Code);
            //                Console.WriteLine(result.Message);
            //                Console.WriteLine(result.Data?.ToString());
            //                Console.WriteLine(result.Data?.Name);
            //            }

            //        Thread.Sleep(500);
            //    }
            //});

            //var result = service.CallResult<IData, ActionResult<TestModel>>(l => l.GetTestModelByID("22525525"));

            //if (result != null)
            //{
            //    Console.WriteLine(result.Code);
            //    Console.WriteLine(result.Message);
            //    Console.WriteLine(result.Data?.ID);
            //    Console.WriteLine(result.Data?.Name);
            //}

            //var result = service.Call<IData, CallResult> (l => l.DeleteTestModelByID("22525525"));

            //if (result != null)
            //{
            //    Console.WriteLine(result.Code);
            //    Console.WriteLine(result.Message);
            //}

            CallBackTest(service);

            Console.Read();

        }


        /// <summary> 回掉函数应用示例 </summary>
        static void CallBackTest(IClientService service)
        { 
            //  Do ：回掉函数

            IMessageCallBack callBack = new MessageCallBack();

            //ContractClient contract = new ContractClient(callBack);

            callBack.CallBack += l => Console.WriteLine(DateTime.Now + " - CallBack:" + l);

            var result = service.DuplexCall<IMyContract, CallResult, IMessageCallBack>(l => l.Do(), callBack);

            Console.WriteLine(result?.Code);
            Console.WriteLine(result?.Message);
        }

        /// <summary> 请求响应模式 </summary>
        static void Call(IClientService service)
        {
            Action action = async () =>
              {
                  Console.WriteLine("当前线程ID:" + Thread.CurrentThread.ManagedThreadId);

                  while (true)
                  {

                      var result = await service.CallAsync<IData, CallResult<TestModel>>(l => l.GetTestModelByID("111"));

                      Console.WriteLine("当前线程ID:" + Thread.CurrentThread.ManagedThreadId);

                      if (result != null)
                      {
                          Console.WriteLine(result.Code);
                          Console.WriteLine(result.Message);
                          Console.WriteLine(result.Data?.ToString());
                          Console.WriteLine(result.Data?.Name);
                      }

                      Thread.Sleep(500);
                  }
              };

            action.Invoke();
        }
    }

    class MessageCallBack : IMessageCallBack
    {
        public void OnCallback()
        {
            Console.WriteLine("OnCallback");
        }

        public void OnCallbackMessage(string message)
        {
            Console.WriteLine(message);

            this.CallBack?.Invoke(message);
        }

        public event Action<string> CallBack;
    }
}
