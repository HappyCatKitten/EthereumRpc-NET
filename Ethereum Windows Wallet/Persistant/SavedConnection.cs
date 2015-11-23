using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ethereum.Wallet.Persistant
{
    public class SavedConnection
    {
        public string Uid { get; set; }
        public string Name { get; set; }

        public string Port { get; set; }

        public string Url { get; set; }
    }
}
