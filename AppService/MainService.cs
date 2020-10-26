using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
namespace AppService
{
    public partial class MainService : ServiceBase
    {
        public MainService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ChannelServices.RegisterChannel(new TcpChannel(6868), false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(SmartPhoneBUS), "abc", WellKnownObjectMode.SingleCall);
        }

        protected override void OnStop()
        {
        }
    }
}
