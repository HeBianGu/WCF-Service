using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{

    public class DuplexChannelFactory<T, C> : DuplexChannelFactory<T> where T:class
    {
        static DuplexChannelFactory()
        {
            DuplexClientBase<T, C>.VerifyCallback();
        }

        public static T CreateChannel(C callback, string endpointName)
        {
            return DuplexChannelFactory<T>.CreateChannel(callback, endpointName);
        }

        public static T CreateChannel(InstanceContext<C> context, string endpointName)
        {
            return DuplexChannelFactory<T>.CreateChannel(context.Context, endpointName);
        }

        public static T CreateChannel(InstanceContext<C> context, Binding binding, string endpointName)
        {
            return DuplexChannelFactory<T>.CreateChannel(context.Context, endpointName);
        }
        public static T CreateChannel(InstanceContext<C> context, Binding binding, EndpointAddress endpointAddress)
        {
            return DuplexChannelFactory<T>.CreateChannel(context.Context, binding, endpointAddress);
        }

        public static T CreateChannel(C callbackObject, Binding binding, EndpointAddress endpointAddress)
        {
            return DuplexChannelFactory<T>.CreateChannel(callbackObject, binding, endpointAddress);
        }

        public DuplexChannelFactory(C callback) : base(callback)
        {

        }
        public DuplexChannelFactory(C callback, string endPointName) : base(callback, endPointName)
        {

        }
        public DuplexChannelFactory(InstanceContext<C> context, string endPointName) : base(context.Context, endPointName)
        {

        }

        public DuplexChannelFactory(C callback, Binding binding, EndpointAddress remoteAddress) : base(callback, binding, remoteAddress)
        {

        }

    }
}
