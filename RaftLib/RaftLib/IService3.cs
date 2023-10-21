using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RaftLib
{
    [ServiceContract]
    public interface IService3
    {
        [OperationContract]
        int GetNumber();
    }
}
