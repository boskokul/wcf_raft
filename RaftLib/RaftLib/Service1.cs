using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaftLib
{
    public class Service1 : IService1
    {
        public int GetSum(int num1, int num2)
        {
            return num1 + num2;
        }

    }
}
