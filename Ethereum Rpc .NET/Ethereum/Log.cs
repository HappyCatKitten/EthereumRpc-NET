using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc.Ethereum
{
    public class Log
    {
        /// <summary>
        /// TAG - pending when the log is pending.mined if log is already mined.
        /// </summary>
        [JsonProperty(PropertyName = "type", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// integer of the log index position in the block. null when its pending log.
        /// </summary>
        [JsonProperty(PropertyName = "logIndex", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LogIndex { get; set; }

        /// <summary>
        /// integer of the transactions index position log was created from. null when its pending log.
        /// </summary>
        [JsonProperty(PropertyName = "transactionIndex", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string TransactionIndex { get; set; }

        /// <summary>
        /// hash of the transactions this log was created from. null when its pending log.
        /// </summary>
        [JsonProperty(PropertyName = "transactionHash", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string TransactionHash { get; set; }

        /// <summary>
        /// hash of the block where this log was in. null when its pending. null when its pending log.
        /// </summary>
        [JsonProperty(PropertyName = "blockHash", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string BlockHash { get; set; }

        /// <summary>
        /// the block number where this log was in. null when its pending. null when its pending log.
        /// </summary>
        [JsonProperty(PropertyName = "blockNumber", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string BlockNumber { get; set; }

        /// <summary>
        /// address from which this log originated.
        /// </summary>
        [JsonProperty(PropertyName = "address", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }

        /// <summary>
        /// contains one or more 32 Bytes non-indexed arguments of the log.
        /// </summary>
        [JsonProperty(PropertyName = "data", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Data { get; set; }

        /// <summary>
        /// Array of 0 to 4 32 Bytes DATA of indexed log arguments. (In solidity: The first topic is the hash of the signature of the event (e.g. Deposit(address,bytes32,uint256)), except you declared the event with the anonymous specifier.)
        /// </summary>
        //[JsonProperty(PropertyName = "topics", Order = 0, DefaultValueHandling = DefaultValueHandling.Ignore)]
        //public string Topics { get; set; }

        public Log(dynamic value)
        {
            Address = value.address;
            Data = value.data;
            BlockNumber = value.blockNumber;
            BlockHash = value.blockHash;
            LogIndex = value.logIndex;
            TransactionHash = value.transactionHash;
            TransactionIndex = value.transactionIndex;
        }
    }
}
