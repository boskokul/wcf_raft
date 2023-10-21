using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class KeepAliveService : IKeepAliveService
    {
        public void SendKeepAlive()
        {
            Console.WriteLine("Keep-alive message received.");
        }
    }
}
