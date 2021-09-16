using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{
    [ServiceContract]
    public class CallResult : CallResult<string>
    {
        public static CallResult Ok(string message= "运行完成")
        { 
            return new CallResult() { Code = true, Message = message };
        }

        public static CallResult Error(string message)
        {
            return new CallResult() { Code = false, Message = message };
        }
    }
    
    public class CallResult<T> : CallResultBase where T:class
    {
        public T Data { get; set; }
    }
    
    public abstract class CallResultBase : ICallResult
    {
       public bool Code { get; set; }

       public string Message { get; set; }
    }

    [ServiceContract]
    public interface ICallResult
    {
        bool Code { get; set; }

        string Message { get; set; }
        

    }
    
 
}
