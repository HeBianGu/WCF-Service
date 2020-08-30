using HeBianGu.General.WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.Data
{
    [ServiceContract]
   public class TestModel
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
