using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService), new Uri("http://localhost:9002/CalculatorService")))
            {
                host.Open();
                Console.WriteLine("Service is running. Press Enter to stop.");
                Console.ReadLine();
            }
        }
    }
}
