//using HeBianGu.General.Data.Interface;
//using HeBianGu.General.WcfService;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HeBianGu.App.Demo.WcfClient
//{
//    internal class ContractClient : DuplexClientBase<IMyContract, IMessageCallBack>, IMyContract
//    {

//        public ContractClient(InstanceContext<IMessageCallBack> context) : base(context)
//        {

//        }

//        public ContractClient(IMessageCallBack callback) : base(callback)
//        {

//        }
//        public CallResult Do()
//        {
//            return this.Channel.Do();
//        }
//    }
//}
