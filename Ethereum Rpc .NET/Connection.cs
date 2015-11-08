using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EthereumRpc
{
    public class Connection
    {
        public string Url { get; set; }
        public string Port { get; set; }
        public WebProxy Proxy { get; set; }
    }
}
