using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc.Ethereum
{
    public class Whisper
    {
        /// <summary>
        /// 60 Bytes - (optional) The identity of the sender.
        /// </summary>
        [JsonProperty(PropertyName = "from", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string From { get; set; }

        /// <summary>
        /// 60 Bytes - (optional) The identity of the receiver.When present whisper will encrypt the message so that only the receiver can decrypt it.
        /// </summary>
        [JsonProperty(PropertyName = "to", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string To { get; set; }

        /// <summary>
        /// Array of DATA - Array of DATA topics, for the receiver to identify messages.
        /// </summary>
        [JsonProperty(PropertyName = "topics", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string[] Topics { get; set; }

        /// <summary>
        /// The payload of the message.
        /// </summary>
        [JsonProperty(PropertyName = "payload", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Payload { get; set; }

        /// <summary>
        /// The integer of the priority in a rang from... (?).
        /// </summary>
        [JsonProperty(PropertyName = "priority", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Priority { get; set; }

        /// <summary>
        /// integer of the time to live in seconds.
        /// </summary>
        [JsonProperty(PropertyName = "ttl", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Ttl { get; set; }
    }
}
