using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EthereumRpc.Ethereum
{
    public class Block
    {
        /// <summary>
        /// the block number. null when its pending block.
        /// </summary>
        [JsonProperty(PropertyName = "number", Order = 0)]
        public string Number { get; set; }

        /// <summary>
        /// hash of the block. null when its pending block.
        /// </summary>
        [JsonProperty(PropertyName = "hash", Order = 0)]
        public byte[] Hash { get; set; }

        /// <summary>
        ///  hash of the parent block.
        /// </summary>
        [JsonProperty(PropertyName = "parentHash", Order = 0)]
        public byte[] ParentHash { get; set; }

        /// <summary>
        /// hash of the generated proof-of-work. null when its pending block.
        /// </summary>
        [JsonProperty(PropertyName = "nonce", Order = 0)]
        public byte[] Nonce { get; set; }

        /// <summary>
        /// SHA3 of the uncles data in the block.
        /// </summary>
        [JsonProperty(PropertyName = "sha3Uncles", Order = 0)]
        public byte[] Sha3Uncles { get; set; }

        /// <summary>
        /// the bloom filter for the logs of the block. null when its pending block.
        /// </summary>
        [JsonProperty(PropertyName = "logsBloom", Order = 0)]
        public byte[] LogsBloom { get; set; }

        /// <summary>
        /// the root of the transaction trie of the block.
        /// </summary>
        [JsonProperty(PropertyName = "transactionsRoot", Order = 0)]
        public byte[] TransactionsRoot { get; set; }

        /// <summary>
        /// the root of the final state trie of the block.
        /// </summary>
        [JsonProperty(PropertyName = "stateRoot", Order = 0)]
        public byte[] StateRoot { get; set; }


        /// <summary>
        /// the root of the receipts trie of the block.
        /// </summary>
        [JsonProperty(PropertyName = "receiptsRoot", Order = 0)]
        public byte[] ReceiptsRoot { get; set; }

        /// <summary>
        /// the address of the beneficiary to whom the mining rewards were given.
        /// </summary>
        [JsonProperty(PropertyName = "miner", Order = 0)]
        public byte[] Miner { get; set; }

        /// <summary>
        ///  integer of the difficulty for this block.
        /// </summary>
        [JsonProperty(PropertyName = "difficulty", Order = 0)]
        public int difficulty { get; set; }







//totalDifficulty: QUANTITY - integer of the total difficulty of the chain until this block.
//extraData: DATA - the "extra data" field of this block.
//size: QUANTITY - integer the size of this block in bytes.
//gasLimit: QUANTITY - the maximum gas allowed in this block.
//gasUsed: QUANTITY - the total used gas by all transactions in this block.
//timestamp: QUANTITY - the unix timestamp for when the block was collated.
//transactions: Array - Array of transaction objects, or 32 Bytes transaction hashes depending on the last given parameter.
//uncles: Array - Array of uncle hashes.
    }
}
