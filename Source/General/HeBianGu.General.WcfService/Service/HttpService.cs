using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{
    public class HttpService : NetServiceBase<BasicHttpBinding>, IServerService
    {

        string _hostFormat = "http://{0}:{1}/";

        string _serverFormat = "http://{0}:{1}/{2}";

        public HttpService(string ip, string port) : base(ip, port)
        {

        } 

        public override void Register<I, T>()
        {
            this.Register<I, T, BasicHttpBinding>(new Uri(string.Format(_hostFormat, _ip, _port)), l =>
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
