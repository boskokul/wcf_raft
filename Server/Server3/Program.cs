using Server3;
using Server3.Server1;
using System;
using System.ServiceModel;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Open a channel to Server1
            var server1Channel = new CalculatorServiceClient("Server2");

            // Open a channel to Server3
            var server3Channel = new CalculatorServiceClient("Server3");

            using (ServiceHost host = new ServiceHost(typeof(CalculatorService), new Uri("http://localhost:9002/CalculatorService")))
            {
                host.Open();
                Console.WriteLine("Service is running. Press Enter to stop.");
                Console.ReadLine();
            }
        }
    }
}
