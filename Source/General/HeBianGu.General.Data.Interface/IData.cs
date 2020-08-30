using HeBianGu.General.WcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.Data.Interface
{
    [ServiceContract]
    public interface IData
    {
        [OperationContract]
        CallResult GetResult();

        [OperationContract]
        CallResult<List<TestModel>> GetTestModel();

        [OperationContract]
        CallResult<TestModel> GetTestModelByID(string id);

        [OperationContract]
        CallResult DeleteTestModelByID(string id);

    }
}
