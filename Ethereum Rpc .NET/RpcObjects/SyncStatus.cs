using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc.Converters;
using Newtonsoft.Json;

namespace EthereumRpc.RpcObjects
{
    public class SyncStatus
    {

        [JsonProperty(PropertyName = "startingBlock", Order = 0, ItemConverterType = typeof(HexToIntConverter))]
        public int StartingBlock { get; set; }

        [JsonProperty(PropertyName = "currentBlock", Order = 0, ItemConverterType = typeof(HexToIntConverter))]
        public int CurrentBlock { get; set; }

        [JsonProperty(PropertyName = "highestBlock", Order = 0, ItemConverterType = typeof(HexToIntConverter))]
        public int HighestBlock { get; set; }
    }
}
