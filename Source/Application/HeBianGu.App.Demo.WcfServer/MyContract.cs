using HeBianGu.General.Data.Interface;
using HeBianGu.General.WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.App.Demo.WcfServer
{

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    class MyContract : IMyContract
    {
        public CallResult Do()
        {
            IMessageCallBack callBack = OperationContext.Current.GetCallbackChannel<IMessageCallBack>();

            callBack.OnCallbackMessage("开始运行");

           callBack.OnCallback();

            callBack.OnCallbackMessage("运行结束");


            return CallResult.Ok();

        }
    }
}
