using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfService
{
    public class MsmqService : ServiceBase<NetMsmqBinding>, IServerService, IClientService
    {
        string _format = "net.msmq://localHost";

        string _serverFormat = "net.msmq://localHost/{0}";

        public override void Register<I, T>() 
        {
            this.Register<I, T, NetMsmqBinding>(new Uri(_format), l =>
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
            return new Uri(_format);
        }

        protected override string GetServerUri(string serverName)
        {
            return string.Format(_serverFormat, serverName);
        }
    }
}
