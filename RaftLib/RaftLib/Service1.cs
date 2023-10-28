using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Timers;

namespace RaftLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private const int HeartBeatIterval = 11900;
        public int Id { get; set; }
        public static int LeaderId { get; set; }
        public string[] Addresses { get; set; }
        public string[] Names { get; set; }
        private int _TimerNumber;
        private Timer Timer;
        private Timer heart;
        
        public int VoteRequested { get; set; }
        public int VotedFor { get; set; }
        private static Random random = new Random();
        public Service1(int id, string[] address, string[] names) {
            Id = id;
            Addresses= address;
            Names = names;
            VotedFor= 0;
            VoteRequested= 0;
            _TimerNumber = 1000*(random.Next(1, 6) + 10);
            Console.WriteLine("Server " + Id + ": " + _TimerNumber + "ms");
            StartTimer();
            heart = new Timer(HeartBeatIterval);
            heart.AutoReset = true;
            heart.Elapsed += (s, e) =>
            {
                SendHeartBeat();
            };
            heart.Stop();
        }

        private void StartTimer()
        {
            Timer = new Timer(_TimerNumber);
            Timer.AutoReset = true;
            Timer.Elapsed += Elapsed; 
            Timer.Start();
        }

        private void Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Server elapsed " + Id);
            LeaderId = 0;
            if (VoteRequested == 0)
            {
                VotedFor = Id;
                Timer.Stop();
                SendVoteRequest();
            }
        }

        public void SendVoteRequest()
        {
            List<int> votes = new List<int>();
            for(int i = 0; i<Names.Length; i++)
            {
                if (i != Id - 1)
                {
                    Uri tcpUri = new Uri($"net.tcp://{Addresses[i]}/{Names[i]}");

                    EndpointAddress adress = new EndpointAddress(tcpUri);

                    NetTcpBinding clientBinding = new NetTcpBinding();

                    ChannelFactory<IService1> factory = new ChannelFactory<IService1>(clientBinding, adress);

                    IService1 service1 = factory.CreateChannel();
                    votes.Add(service1.SendVoteResponse(Id));
                }
                else
                {
                    continue;
                }
            }
            if (votes.Contains(Id))
            {
                ProclaimAsTheLeader();
            }
        }

        public int SendVoteResponse(int id)
        {
            Timer.Stop();
            heart.Stop();
            heart.Interval = HeartBeatIterval;
            if (VotedFor == 0)
            {
                VoteRequested = id;
                VotedFor = VoteRequested;
                Console.WriteLine(Id + " voted for " + VotedFor);
                return id;
            }
            else
            {
                Console.WriteLine(Id + " voted for " + VotedFor);
                return VotedFor;
            }
        }

        public void ProclaimAsTheLeader()
        {
            VotedFor= 0;
            VoteRequested= 0;
            LeaderId = Id;
            bool ok = true;
            for (int i = 0; i < Names.Length; i++)
            {
                if (i != Id - 1)
                {
                    Uri tcpUri = new Uri($"net.tcp://{Addresses[i]}/{Names[i]}");

                    EndpointAddress adress = new EndpointAddress(tcpUri);

                    NetTcpBinding clientBinding = new NetTcpBinding();

                    ChannelFactory<IService1> factory = new ChannelFactory<IService1>(clientBinding, adress);

                    IService1 service1 = factory.CreateChannel();
                    ok = ok && service1.RecieveLeader(Id);
                }
            }
            if (ok)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Id + " is the leader.");
                Console.ResetColor();
                heart.Start();
            }
        }

        public void SendHeartBeat()
        {
            for (int i = 0; i < Names.Length; i++)
            {
                if (i != Id - 1)
                {
                    Uri tcpUri = new Uri($"net.tcp://{Addresses[i]}/{Names[i]}");

                    EndpointAddress adress = new EndpointAddress(tcpUri);

                    NetTcpBinding clientBinding = new NetTcpBinding();

                    ChannelFactory<IService1> factory = new ChannelFactory<IService1>(clientBinding, adress);

                    IService1 service1 = factory.CreateChannel();
                    service1.RecieveHeartBeat(Id);
                }
            }
        }

        public void RecieveHeartBeat(int id)
        {
            if (id == LeaderId)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(Id + " recieved heart beat from " + LeaderId);
                Console.ResetColor();
                RestartTimer();
            }
        }


        public bool RecieveLeader(int id)
        {
            VotedFor = 0;
            VoteRequested = 0;
            heart.Stop();
            LeaderId= id;
            RestartTimer();
            return true;
        }
        private void RestartTimer()
        {
            Timer.Stop();
            Timer.Interval = _TimerNumber;
            Timer.Start();
        }
    }
}
