using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{
    /// <summary> 类型安装队额毁掉对象提供类 T :服务契约 C:回调类型 </summary>
    public abstract class DuplexClientBase<T, C> : DuplexClientBase<T> where T:class
    {
        protected DuplexClientBase(InstanceContext<C> context) : base(context.Context)
        {

        }

        protected DuplexClientBase(C callback) : base(callback)
        {

        }


        protected DuplexClientBase(InstanceContext<C> context, string endpointName) : base(context.Context, endpointName)
        {

        }

        protected DuplexClientBase(InstanceContext<C> context, ServiceEndpoint endpoint) : base(context.Context, endpoint)
        {

        }

        protected DuplexClientBase(InstanceContext<C> context, string endpointConfigurationName, string remoteAddress) : base(context.Context, endpointConfigurationName, remoteAddress)
        {

        }
        protected DuplexClientBase(InstanceContext<C> context, string endpointConfigurationName, EndpointAddress remoteAddress) : base(context.Context, endpointConfigurationName, remoteAddress)
        {

        }
        protected DuplexClientBase(InstanceContext<C> context, Binding binding, EndpointAddress remoteAddress) : base(context.Context, binding, remoteAddress)
        {

        }

        static DuplexClientBase()
        {
            VerifyCallback();
        }

        /// <summary> 验证Callback </summary>
        internal static void VerifyCallback()
        {
            Type contractType = typeof(T);

            Type callbackType = typeof(C);

            object[] attributes = contractType.GetCustomAttributes(typeof(ServiceContractAttribute), false);

            if (attributes.Length == 0)
            {
                throw new InvalidProgramException("Type of" + contractType + " is not a service contract");
            }

            ServiceContractAttribute serviceAttribute;

            serviceAttribute = attributes[0] as ServiceContractAttribute;

            if (callbackType != serviceAttribute.CallbackContract)
            {
                throw new InvalidProgramException("Type of" + contractType + " is not configured as callback contract for " + contractType);
            }
        }

    }
}
