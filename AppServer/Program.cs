using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
namespace AppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpChannel(6868), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(SmartPhoneBUS), "abc", WellKnownObjectMode.SingleCall);
            Console.WriteLine("Server is running");
            Console.Read();
        }
    }
}
