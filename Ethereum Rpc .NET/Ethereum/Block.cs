using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc.RpcObjects;
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
        public string Hash { get; set; }

        /// <summary>
        ///  hash of the parent block.
        /// </summary>
        [JsonProperty(PropertyName = "parentHash", Order = 0)]
        public string ParentHash { get; set; }

        /// <summary>
        /// hash of the generated proof-of-work. null when its pending block.
        /// </summary>
        [JsonProperty(PropertyName = "nonce", Order = 0)]
        public string Nonce { get; set; }

        /// <summary>
        /// SHA3 of the uncles data in the block.
        /// </summary>
        [JsonProperty(PropertyName = "sha3Uncles", Order = 0)]
        public string Sha3Uncles { get; set; }

        /// <summary>
        /// the bloom filter for the logs of the block. null when its pending block.
        /// </summary>
        [JsonProperty(PropertyName = "logsBloom", Order = 0)]
        public string LogsBloom { get; set; }

        /// <summary>
        /// the root of the transaction trie of the block.
        /// </summary>
        [JsonProperty(PropertyName = "transactionsRoot", Order = 0)]
        public string TransactionsRoot { get; set; }

        /// <summary>
        /// the root of the final state trie of the block.
        /// </summary>
        [JsonProperty(PropertyName = "stateRoot", Order = 0)]
        public string StateRoot { get; set; }


        /// <summary>
        /// the root of the receipts trie of the block.
        /// </summary>
        [JsonProperty(PropertyName = "receiptsRoot", Order = 0)]
        public string ReceiptsRoot { get; set; }

        /// <summary>
        /// the address of the beneficiary to whom the mining rewards were given.
        /// </summary>
        [JsonProperty(PropertyName = "miner", Order = 0)]
        public string Miner { get; set; }

        /// <summary>
        ///  integer of the difficulty for this block.
        /// </summary>
        [JsonProperty(PropertyName = "difficulty", Order = 0)]
        public string Difficulty { get; set; }

        /// <summary>
        /// integer of the total difficulty of the chain until this block.
        /// </summary>
        [JsonProperty(PropertyName = "totalDifficulty", Order = 0)]
        public string TotalDifficulty { get; set; }

        /// <summary>
        /// the "extra data" field of this block.
        /// </summary>
        [JsonProperty(PropertyName = "extraData", Order = 0)]
        public string ExtraData { get; set; }

        /// <summary>
        /// integer the size of this block in bytes.
        /// </summary>
        [JsonProperty(PropertyName = "size", Order = 0)]
        public string Size { get; set; }

        /// <summary>
        ///  the maximum gas allowed in this block.
        /// </summary>
        [JsonProperty(PropertyName = "gasLimit", Order = 0)]
        public string GasLimit { get; set; }

        /// <summary>
        /// the total used gas by all transactions in this block.
        /// </summary>
        [JsonProperty(PropertyName = "gasUsed", Order = 0)]
        public string GasUsed { get; set; }

        /// <summary>
        /// the unix timestamp for when the block was collated.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp", Order = 0)]
        public string Timestamp { get; set; }

        /// <summary>
        /// Array of transaction objects, or 32 Bytes transaction hashes depending on the last given parameter.
        /// </summary>
        [JsonProperty(PropertyName = "transactionHashes", Order = 0)]
        public List<string> TransactionHashes { get; set; }

        [JsonProperty(PropertyName = "transactionsFull", Order = 0)]
        public List<Transaction> TransactionsFull { get; set; }


        /// <summary>
        /// Array of uncle hashes.
        /// </summary>
        [JsonProperty(PropertyName = "uncles", Order = 0)]
        public List<string> Uncles { get; set; }
    }
}
