using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{
    public abstract class ServiceBase<B> : ServiceBase, IServerService, IClientService where B : Binding
    {

        public virtual void Register<I, T>() where T : class
        {
            this.Register<I, T, B>(this.GetHostUri(), l =>
              {
                  l.ReceiveTimeout = new TimeSpan(1, 0, 0);
                  l.OpenTimeout = new TimeSpan(0, 5, 0);
                  l.CloseTimeout = new TimeSpan(0, 5, 0);
                  l.SendTimeout = new TimeSpan(0, 5, 0);
              });
        }

        public virtual void Register<I, T>(Action<Binding> bindingBuilder = null) where T : class
        {
            base.Register<I, T, B>(this.GetHostUri(), bindingBuilder);
        }

        protected abstract Uri GetHostUri();
        protected abstract string GetServerUri(string serverName);
        
        public R DuplexCall<I,R,C>(Func<I, R> action, C callBack) where I : class where R : class, ICallResult
        {
            string serverName = typeof(I).Name;

           return this.DuplexDo<I,R, B, C>(action, callBack,this.GetServerUri(serverName));
        }

        public  R Call<I,R>(Func<I, R> action) where R : class, ICallResult
        {
            string serverName = typeof(I).Name;

           return this.Do<I, B,R>(action, this.GetServerUri(serverName));
        }

        public async Task<R> DuplexCallAsync<I, R, C>(Func<I, R> action, C callBack) where I : class where R : class, ICallResult
        {  
          return await Task.Run(()=>this.DuplexCall(action,callBack));
        }

        public async Task<R> CallAsync<I, R>(Func<I, R> action) where R : class, ICallResult
        {
            return await Task.Run(() => this.Call(action));
        }
    }

}
