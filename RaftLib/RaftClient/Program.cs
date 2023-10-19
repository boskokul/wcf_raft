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
            string serviceAddress = "127.0.0.1:10001";
            string serviceName = "RaftService";

            Uri tcpUri = new Uri($"net.tcp://{serviceAddress}/{serviceName}");

            EndpointAddress adress = new EndpointAddress(tcpUri);

            NetTcpBinding clientBinding = new NetTcpBinding();

            ChannelFactory<IService1> factory = new ChannelFactory<IService1>(clientBinding, adress);

            IService1 service = factory.CreateChannel();

            //Testing 
            Console.Write("Enter the first number: ");
            int number1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the second number: ");
            int number2 = int.Parse(Console.ReadLine());

            int sum = service.GetSum(number1, number2);

            Console.WriteLine($"Resulting sum = {sum}");

            Console.ReadLine();
        }
    }
}
