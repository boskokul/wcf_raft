using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaftLib;

namespace RaftClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceAddress = "127.0.0.1:4001";
            string serviceName = "RaftService";

            Uri tcpUri = new Uri($"net.tcp://{serviceAddress}/{serviceName}");

            EndpointAddress adress = new EndpointAddress(tcpUri);

            NetTcpBinding clientBinding = new NetTcpBinding();

            ChannelFactory<IService1> factory = new ChannelFactory<IService1>(clientBinding, adress);

            IService1 service = factory.CreateChannel();

            //Testing 
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            int sum = service.GetMultiplication(number);

            Console.WriteLine($"Result= {sum}");

            Console.ReadLine();
        }
    }
}
