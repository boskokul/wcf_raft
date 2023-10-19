using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaftLib
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        int GetSum(int num1, int num2);

    }

}
