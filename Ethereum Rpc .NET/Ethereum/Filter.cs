using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc.Ethereum
{
    public class Filter
    {
        /// <summary>
        /// (optional, default: "latest") Integer block number, or "latest" for the last mined block or "pending", "earliest" for not yet mined transactions.
        /// </summary>
        [JsonProperty(PropertyName = "fromBlock", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FromBlock { get; set; }

        /// <summary>
        /// (optional, default: "latest") Integer block number, or "latest" for the last mined block or "pending", "earliest" for not yet mined transactions.
        /// </summary>
        [JsonProperty(PropertyName = "toBlock", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ToBlock { get; set; }

        /// <summary>
        ///  (optional) Contract address or a list of addresses from which logs should originate.
        /// </summary>
        [JsonProperty(PropertyName = "address", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }

        /// <summary>
        /// (optional) Array of 32 Bytes DATA topics.Each topic can also be an array of DATA with "or" options.
        /// </summary>
        [JsonProperty(PropertyName = "topics", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] Topics { get; set; }

        public Filter(string fromBlock = null, string toBlock = null,BlockTag from = BlockTag.Earliest, BlockTag to = BlockTag.Pending, string address = null, string[] topics = null)
        {
            FromBlock = fromBlock ?? from.ToJsonMethodName();
            ToBlock = toBlock ?? to.ToJsonMethodName();
            Address = address;
            Topics = topics;
        }
    }
}
