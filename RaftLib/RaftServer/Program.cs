using RaftLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RaftServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceAddress = "127.0.0.1:4001";
            string serviceName = "RaftService";

            ServiceHost host = new ServiceHost(typeof(Service1), new Uri($"net.tcp://{serviceAddress}/{serviceName}"));

            NetTcpBinding serverBinding = new NetTcpBinding();

            host.AddServiceEndpoint(typeof(IService1), serverBinding, "");
            host.Open();

            Console.WriteLine("Service is running. Press Enter to stop.");
            Console.ReadLine();
        }
    }
}
