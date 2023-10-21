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
        public int GetMultiplication(int num)
        {
            string serviceAddress2 = "127.0.0.1:4002";
            string serviceName2 = "RaftService2";

            Uri tcpUri2 = new Uri($"net.tcp://{serviceAddress2}/{serviceName2}");

            EndpointAddress adress2 = new EndpointAddress(tcpUri2);

            NetTcpBinding clientBinding2 = new NetTcpBinding();

            ChannelFactory<IService2> factory2 = new ChannelFactory<IService2>(clientBinding2, adress2);

            IService2 service2 = factory2.CreateChannel();

            string serviceAddress3 = "127.0.0.1:4003";
            string serviceName3 = "RaftService3";

            Uri tcpUri3 = new Uri($"net.tcp://{serviceAddress3}/{serviceName3}");

            EndpointAddress adress3 = new EndpointAddress(tcpUri3);

            NetTcpBinding clientBinding3 = new NetTcpBinding();

            ChannelFactory<IService3> factory3 = new ChannelFactory<IService3>(clientBinding3, adress3);

            IService3 service3 = factory3.CreateChannel();

            return service2.GetNumber()*service3.GetNumber()*num;
        }
    }
}
