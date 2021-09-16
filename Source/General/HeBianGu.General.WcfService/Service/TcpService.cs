using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{
    public class TcpService : NetServiceBase<NetTcpBinding>
    {
        string _hostFormat = "net.tcp://{0}:{1}/";

        string _serverFormat = "net.tcp://{0}:{1}/{2}";

        public TcpService(string ip, string port) : base(ip, port)
        {

        }

        public override void Register<I>(object instance)
        {
            this.Register<I, NetTcpBinding>(new Uri(string.Format(_hostFormat, _ip, _port)), instance, l =>
            {
                l.MaxBufferPoolSize = int.MaxValue;
                l.MaxReceivedMessageSize = int.MaxValue;
                l.ReceiveTimeout = new TimeSpan(1, 0, 0);
                l.OpenTimeout = new TimeSpan(0, 5, 0);
                l.CloseTimeout = new TimeSpan(0, 5, 0);
                l.SendTimeout = new TimeSpan(0, 5, 0);
            });
        }

        public override void Register<I, T>()
        {
            this.Register<I, T, NetTcpBinding>(new Uri(string.Format(_hostFormat, _ip, _port)), l =>
              {
                  l.MaxBufferPoolSize = int.MaxValue;
                  l.MaxReceivedMessageSize = int.MaxValue;
                  l.ReceiveTimeout = new TimeSpan(1, 0, 0);
                  l.OpenTimeout = new TimeSpan(0, 5, 0);
                  l.CloseTimeout = new TimeSpan(0, 5, 0);
                  l.SendTimeout = new TimeSpan(0, 5, 0);
              });
        }

        protected override Uri GetHostUri()
        {
            return new Uri(string.Format(_serverFormat, _ip, _port));
        }

        protected override string GetServerUri(string serverName)
        {
            return string.Format(_serverFormat, _ip, _port, serverName);
        }
    }
}
