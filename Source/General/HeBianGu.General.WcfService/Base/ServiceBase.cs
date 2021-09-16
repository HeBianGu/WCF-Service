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
    public abstract class ServiceBase : IDisposable
    {
        List<ServiceHost> serviceHosts = new List<ServiceHost>();


        /// <summary> 根据传递的接口 实例 和绑定类型注册Host </summary>
        protected object Register<I, B>(Uri baseAddresses, object instance, Action<B> bindingBuilder = null) where B : Binding
        {
            string ServerName = nameof(I);

            ServiceHost host = new ServiceHost(instance, baseAddresses);

            var b = Activator.CreateInstance<B>();

            bindingBuilder?.Invoke(b);

            host.AddServiceEndpoint(typeof(I), b, ServerName);

            //关闭状态处理
            host.Closed += (sender, e) =>
            {
                this.Closed?.Invoke(sender, e);

                //如果意外关闭，再次打开监听
                if (isStop) return;

                this.serviceHosts.Remove(host);

                this.Register<I, B>(baseAddresses, instance, bindingBuilder);
            };

            //  Message：注册事件
            host.Opening += this.Opening;
            host.Opened += this.Opened;
            host.Faulted += this.Faulted;

            host.Open();

            return host.SingletonInstance;
        }


        /// <summary> 根据传递的接口 实例 和绑定类型注册Host </summary>
        protected void Register<I, T, B>(Uri baseAddresses, Action<B> bindingBuilder = null) where T : class where B : Binding
        {
            string ServerName = typeof(I).Name;

            ServiceHost host = new ServiceHost(typeof(T), baseAddresses);

            var b = Activator.CreateInstance<B>();

            bindingBuilder?.Invoke(b);

            host.AddServiceEndpoint(typeof(I), b, ServerName);

            //关闭状态处理
            host.Closed += (sender, e) =>
            {
                this.Closed?.Invoke(sender, e);

                //如果意外关闭，再次打开监听
                if (isStop) return;

                this.serviceHosts.Remove(host);

                this.Register<I, T, B>(baseAddresses, bindingBuilder);
            };

            //  Message：注册事件
            host.Opening += this.Opening;
            host.Opened += this.Opened;
            host.Faulted += this.Faulted;

            host.Open();
        }

        public void Dispose()
        {
            this.Stop();

            foreach (ServiceHost service in this.serviceHosts)
            {
                //  Message：注册事件
                service.Opening -= this.Opening;
                service.Opened -= this.Opened;
                service.Closed -= this.Closed;
                service.Faulted -= this.Faulted;
            }

            this.serviceHosts.Clear();
            this.serviceHosts = null;
        }

        bool isStop;
        public void Stop()
        {
            isStop = true;

            foreach (ServiceHost service in this.serviceHosts)
            {
                if (service.State != CommunicationState.Closed)
                {
                    service.Close();
                }
            }
        }

        /// <summary>
        /// 客户端调用带有Callback功能
        /// </summary>
        /// <typeparam name="I"> Contract </typeparam>
        /// <typeparam name="B"> Binding </typeparam>
        /// <typeparam name="C"> Callback </typeparam>
        /// <param name="action"> 执行方法 </param>
        /// <param name="url"> Adress </param>
        protected R DuplexDo<I, R, B, C>(Func<I, R> action, C callback, string url) where I : class where R : class, ICallResult
        {
            var b = Activator.CreateInstance<B>() as Binding;

            try
            {
                using (var factory = new DuplexChannelFactory<I, C>(callback, b, new EndpointAddress(url)))
                {
                    var proxy = factory.CreateChannel();

                    return action?.Invoke(proxy);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                R result = Activator.CreateInstance<R>();

                result.Code = false;

                result.Message = ex.Message;

                return result;
            }
        }

        protected R Do<I, B, R>(Func<I, R> action, string url) where R : class, ICallResult
        {
            var b = Activator.CreateInstance<B>() as Binding;

            try
            {
                using (var factory = new ChannelFactory<I>(b, new EndpointAddress(url)))
                {
                    var proxy = factory.CreateChannel();
                    return action?.Invoke(proxy);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

                R result = Activator.CreateInstance<R>();

                result.Code = false;

                result.Message = ex.Message;

                return result;
            }
        }

        public event EventHandler Closed;

        public event EventHandler Faulted;

        public event EventHandler Opened;

        public event EventHandler Opening;
    }
}
