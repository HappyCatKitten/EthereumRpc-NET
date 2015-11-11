using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc.Ethereum
{
    public class Work
    {
        /// <summary>
        /// current block header pow-hash
        /// </summary>
        [JsonProperty(PropertyName = "blockHeaderPowHash", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string BlockHeaderPowHash { get; set; }

        /// <summary>
        /// the seed hash used for the DAG.
        /// </summary>
        [JsonProperty(PropertyName = "seedHash", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SeedHash { get; set; }

        /// <summary>
        /// the boundary condition ("target"), 2^256 / difficulty.
        /// </summary>
        [JsonProperty(PropertyName = "target", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Target { get; set; }

        public override string ToString()
        {
            var value = string.Empty;

            value += string.Format("BlockHeaderPowHash : {0}{1}", BlockHeaderPowHash, Environment.NewLine);
            value += string.Format("SeedHash : {0}{1}", SeedHash, Environment.NewLine);
            value += string.Format("Target : {0}{1}", Target, Environment.NewLine);

            return value;
        }
    }
}
