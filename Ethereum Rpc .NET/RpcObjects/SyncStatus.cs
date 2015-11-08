using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc.RpcObjects
{
    public class SyncStatus
    {

        [JsonProperty(PropertyName = "startingBlock", Order = 0)]
        public int StartingBlock { get; set; }

        [JsonProperty(PropertyName = "currentBlock")]
        public int CurrentBlock { get; set; }

        [JsonProperty(PropertyName = "highestBlock", Order = 0)]
        public int HighestBlock { get; set; }
    }
}
