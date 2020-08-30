using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{

    public abstract class NetServiceBase<B> : ServiceBase<B> where B : Binding
    {
        protected string _ip;

        protected string _port;

        public NetServiceBase(string ip, string port)
        {
            this._ip = ip;
            this._port = port;
        }

    }
}
