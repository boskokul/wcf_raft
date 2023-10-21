using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [ServiceContract(Name = "ICalculatorService")]
    public interface ICalculatorService
    {
        [OperationContract]
        int GetSum(int a, int b);
        [OperationContract]
        int GetMultiply(int a, int b);
    }
}
