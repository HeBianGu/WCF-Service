using HeBianGu.General.Data;
using HeBianGu.General.Data.Interface;
using HeBianGu.General.WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeBianGu.App.Demo.WcfServer
{
    class Data : IData
    {
        public CallResult DeleteTestModelByID(string id)
        {
            return CallResult.Ok("删除成功");
        }

        public void Do()
        {
            //throw new Exception("测试抛出异常");

            //ClipBoardService.Register();

            Console.WriteLine(DateTime.Now);

        }

        public CallResult GetResult()
        {
            return CallResult.Ok("任务完成");
        }

        public CallResult<List<TestModel>> GetTestModel()
        {
            List<TestModel> colletion = new List<TestModel>();
            colletion.Add(new TestModel() { ID = "10000", Name = "信号码率" });
            colletion.Add(new TestModel() { ID = "10000", Name = "信号码率" });

            Thread.Sleep(10000);

            return new CallResult<List<TestModel>>() { Code = true, Message = "任务完成",Data= colletion };
        }

        public CallResult<TestModel> GetTestModelByID(string id)
        {
            Thread.Sleep(5000);

            return new CallResult<TestModel>() { Code = true, Message = "任务完成", Data = new TestModel() { ID = id, Name = DateTime.Now.ToString() } };
        }
    }

    

}
