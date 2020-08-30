using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{
    /// <summary> 类型安装的上线问泛型类 </summary>
    public class InstanceContext<T>
    {
        public InstanceContext Context { get; private set; }

        public InstanceContext(T callbackInstance)
        {
            this.Context = new InstanceContext(callbackInstance);
        }
        public void ReleaseServiceInstance()
        {
            Context.ReleaseServiceInstance();
        }

        public T ServiceInstance
        {
            get
            {
                return (T)Context.GetServiceInstance();
            }
        }
    }
}
