using HeBianGu.General.WcfService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.Data.Interface
{
    [ServiceContract(CallbackContract =typeof(IMessageCallBack))]
    public interface IMyContract
    {
        [OperationContract]
        CallResult Do();
    }

}
