using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class CalculatorService : ICalculatorService
    {
        public int GetMultiply(int a, int b)
        {
            return a * b;
        }

        public int GetSum(int a, int b)
        {
            return a + b;
        }
    }
}
