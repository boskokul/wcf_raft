using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{
    [ServiceContract(Name = "IKeepAliveService")]
    public interface IKeepAliveService
    {
        [OperationContract]
        void SendKeepAlive();
    }
}
