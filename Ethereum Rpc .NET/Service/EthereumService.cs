using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Numerics;
using EthereumRpc.Ethereum;
using EthereumRpc.RpcObjects;
using Newtonsoft.Json;

namespace EthereumRpc
{
    public class EthereumService
    {
        public EthereumService(string url, string port)
        {
            RpcConnector.ConnectionOptions = new ConnectionOptions();
            RpcConnector.ConnectionOptions.Url = url;
            RpcConnector.ConnectionOptions.Port = port;
        }

        public EthereumService(ConnectionOptions connectionOptions)
        {
            RpcConnector.ConnectionOptions = connectionOptions;
        }

        public EthereumService()
        {
            if (RpcConnector.ConnectionOptions == null)
            {
                RpcConnector.ConnectionOptions = new ConnectionOptions();
                var urlString = ConfigurationManager.AppSettings["EthereumRpcUrl"];
                var portString = ConfigurationManager.AppSettings["EthereumRpcPort"];

                RpcConnector.ConnectionOptions.Url = urlString;
                RpcConnector.ConnectionOptions.Port = portString;
            }
        }

        /// <summary>
        /// Returns the current client version
        /// </summary>
        /// <returns>The current client version</returns>
        public string GetWeb3ClientVersion()
        {
            var rpcRequest = new RpcRequest(RpcMethod.web3_clientVersion);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        /// <summary>
        ///  Returns Keccak-256 (not the standardized SHA3-256) of the given data.
        /// </summary>
        /// <param name="value"> the data to convert into a SHA3 hash</param>
        /// <returns>The SHA3 result of the given string.</returns>
        public string GetWeb3Sha3(string value)
        {
            var rpcRequest = new RpcRequest(RpcMethod.web3_sha3);
            rpcRequest.AddParam(value);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        /// <summary>
        /// Returns the current network protocol version.
        /// </summary>
        /// <returns> The current network protocol version</returns>
        public string GetNetVersion()
        {
            var rpcRequest = new RpcRequest(RpcMethod.net_version);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        /// <summary>
        /// Returns true if client is actively listening for network connections.
        /// </summary>
        /// <returns>true when listening, otherwise false.</returns>
        public bool GetNetListening()
        {
            var rpcRequest = new RpcRequest(RpcMethod.net_version);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var isListening = Convert.ToBoolean(Int32.Parse(rpcResult.Result));
            return isListening;
        }

        /// <summary>
        /// Returns number of peers currenly connected to the client.
        /// </summary>
        /// <returns>integer of the number of connected peers.</returns>
        public int GetNetPeerCount()
        {
            var rpcRequest = new RpcRequest(RpcMethod.net_peerCount);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var peerCount = Convert.ToInt32(rpcResult.Result, 16);
            return peerCount;
        }

        /// <summary>
        /// Returns the current ethereum protocol version.
        /// </summary>
        /// <returns>The current ethereum protocol version</returns>
        public string GetProtocolVersion()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_protocolVersion);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        /// <summary>
        /// Returns an object object with data about the sync status or FALSE.
        /// </summary>
        /// <returns></returns>
        public SyncStatus GetSyncing()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_syncing);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            
            if (rpcResult.Result.GetType()!=typeof(Boolean))
            {
                var syncStatus = JsonConvert.DeserializeObject<SyncStatus>(rpcResult.Result);
                
                return syncStatus;
            }

            return new SyncStatus() {IsSyncing = false};
            
        }

        /// <summary>
        /// Returns the client coinbase address.
        /// </summary>
        /// <returns>the current coinbase address.</returns>
        public Address GetCoinbase()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_coinbase);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var address = new Address(rpcResult.Result);
            return address;
        }

        /// <summary>
        /// Returns true if client is actively mining new blocks.
        /// </summary>
        /// <returns>returns true of the client is mining, otherwise false.</returns>
        public bool GetMining()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_mining);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            return rpcResult.Result;
        }

        /// <summary>
        /// Returns the number of hashes per second that the node is mining with.
        /// </summary>
        /// <returns>number of hashes per second.</returns>
        public long GetHashrate()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_hashrate);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var hashRate = Convert.ToInt64(rpcResult.Result, 16);

            return hashRate;
        }

        /// <summary>
        /// Returns the current price per gas in wei.
        /// </summary>
        /// <returns>integer of the current gas price in wei.</returns>
        public long GetGasPrice()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_gasPrice);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var gasPrice = Convert.ToInt64(rpcResult.Result, 16);

            return gasPrice;
        }

        /// <summary>
        /// Returns a list of addresses owned by client.
        /// </summary>
        /// <returns>addresses owned by the client.</returns>
        public string[] GetAccounts()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_accounts);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            var accountList = new List<string>();
            foreach (var account in rpcResult.Result)
            {
                accountList.Add(account.Value);
            }

            return accountList.ToArray();
        }

        /// <summary>
        /// Returns the number of most recent block.
        /// </summary>
        /// <returns> integer of the current block number the client is on.</returns>
        public long GetBlockNumber()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_blockNumber);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var ethBlockNumber = Convert.ToInt64(rpcResult.Result, 16);

            return ethBlockNumber;
        }

        /// <summary>
        /// Returns the balance of the account of given address.
        /// </summary>
        /// <param name="address">address to check for balance.</param>
        /// <param name="blockTag"> integer block number</param>
        /// <param name="blockNumber">Block param</param>
        /// <returns></returns>
        public BigInteger GetBalance(string address, BlockTag blockTag = BlockTag.Quantity, int blockNumber = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getBalance);

            rpcRequest.AddParam(address);

            if (blockTag != BlockTag.Quantity && blockNumber > -1)
            {
                throw new Exception("Balance tag and block number cannot both be provided, chose either");
            }

            if (blockTag != BlockTag.Quantity)
            {
                rpcRequest.AddParam(blockTag.ToJsonMethodName());
            }
            else
            {
                rpcRequest.AddParam(blockNumber.ToString());
            }



            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            if (rpcResult.Result == null)
            {
                return 0;
            }

            string value = rpcResult.Result.ToString();
            var balance = value.ToBigInteger();

            return balance;
        }

        /// <summary>
        /// Returns the value from a storage position at a given address.
        /// </summary>
        /// <param name="address"> address of the storage.</param>
        /// <param name="storagePosition">integer of the position in the storage.</param>
        /// <param name="blockTag">Block Param</param>
        /// <param name="blockNumber">integer block number</param>
        /// <returns>the value at this storage position.</returns>
        public long GetStorageAt(string address,int storagePosition, BlockTag blockTag = BlockTag.Quantity, int blockNumber = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getStorageAt);

            rpcRequest.AddParam(address);
            rpcRequest.AddParam(storagePosition.ToString());

            if (blockTag != BlockTag.Quantity && blockNumber > -1)
            {
                throw new Exception("Balance tag and block number cannot both be provided, chose either");
            }

            if (blockTag != BlockTag.Quantity)
            {
                rpcRequest.AddParam(blockTag.ToJsonMethodName());
            }
            else
            {
                rpcRequest.AddParam(blockNumber.ToString());
            }

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var balance = Convert.ToInt64(rpcResult.Result, 16);

            return balance;
        }

        /// <summary>
        /// Returns the number of transactions sent from an address.
        /// </summary>
        /// <param name="address">address</param>
        /// <param name="blockTag">Block Param</param>
        /// <param name="blockNumber">integer block number,</param>
        /// <returns>integer of the number of transactions send from this address.</returns>
        public long GetTransactionCount(string address, BlockTag blockTag = BlockTag.Quantity, int blockNumber = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getTransactionCount);

            rpcRequest.AddParam(address);

            if (blockTag != BlockTag.Quantity && blockNumber > -1)
            {
                throw new Exception("Balance tag and block number cannot both be provided, chose either");
            }

            if (blockTag != BlockTag.Quantity)
            {
                rpcRequest.AddParam(blockTag.ToJsonMethodName());
            }
            else
            {
                rpcRequest.AddParam(blockNumber.ToString());
            }

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var balance = Convert.ToInt64(rpcResult.Result, 16);

            return balance;
        }

        /// <summary>
        /// Returns the number of transactions in a block from a block matching the given block hash.
        /// </summary>
        /// <param name="blockHash"> hash of a block</param>
        /// <returns> integer of the number of transactions in this block.</returns>
        public long GetBlockTransactionCountByHash(string blockHash)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getBlockTransactionCountByHash);
            //todo validate the 20 byte block hash
            rpcRequest.AddParam(blockHash);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            if (rpcResult.Result == null)
                return 0;

            var count = Convert.ToInt64(rpcResult.Result, 16);

            return count;
        }

        /// <summary>
        /// Returns the number of transactions in a block from a block matching the given block number.
        /// </summary>
        /// <param name="blockTag">Block Param</param>
        /// <param name="blockNumber">integer of a block number,</param>
        /// <returns></returns>
        public long GetBlockTransactionCountByNumber(BlockTag blockTag = BlockTag.Quantity, int blockNumber = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getBlockTransactionCountByNumber);
           
            if (blockTag != BlockTag.Quantity && blockNumber > -1)
            {
                throw new Exception("Balance tag and block number cannot both be provided, chose either");
            }

            if (blockTag != BlockTag.Quantity)
            {
                rpcRequest.AddParam(blockTag.ToJsonMethodName());
            }
            else
            {
                rpcRequest.AddParam(blockNumber.ToString());
            };
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var count = Convert.ToInt64(rpcResult.Result, 16);

            return count;
        }

        /// <summary>
        /// Returns the number of uncles in a block from a block matching the given block hash.
        /// </summary>
        /// <param name="hashBlock">hash of a block</param>
        /// <returns> integer of the number of uncles in this block.</returns>
        public long GetUncleCountByBlockHash(string hashBlock)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getUncleCountByBlockHash);
            rpcRequest.AddParam(hashBlock);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            if (rpcResult.Result == null)
                return 0;

            var ethBlockNumber = Convert.ToInt64(rpcResult.Result, 16);

            return ethBlockNumber;
        }

        /// <summary>
        /// Returns the number of uncles in a block from a block matching the given block number.
        /// </summary>
        /// <param name="blockNumber">integer of a block number</param>
        /// <returns>integer of the number of uncles in this block.</returns>
        public long GetUncleCountByBlockNumber(int blockNumber)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getUncleCountByBlockNumber);
            rpcRequest.AddParam(blockNumber.ToHexString());
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var ethBlockNumber = Convert.ToInt64(rpcResult.Result, 16);

            return ethBlockNumber;
        }

        /// <summary>
        /// Returns code at a given address.
        /// </summary>
        /// <param name="address">address</param>
        /// <param name="blockTag"></param>
        /// <param name="blockNumber">integer block number,</param>
        /// <returns></returns>
        public string GetCode(string address, BlockTag blockTag = BlockTag.Quantity, int blockNumber = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getCode);
            rpcRequest.AddParam(address);

            if (blockTag != BlockTag.Quantity && blockNumber > -1)
            {
                throw new Exception("Balance tag and block number cannot both be provided, chose either");
            }

            if (blockTag != BlockTag.Quantity)
            {
                rpcRequest.AddParam(blockTag.ToJsonMethodName());
            }
            else
            {
                rpcRequest.AddParam(blockNumber.ToHexString());
            };
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            return rpcResult.Result;
        }

        /// <summary>
        /// Signs data with a given address.
        /// </summary>
        /// <param name="address">address</param>
        /// <param name="data">Data to sign</param>
        /// <returns>Signed data</returns>
        public string Sign(string address, string data)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_sign);
            rpcRequest.AddParam(address);
            rpcRequest.AddParam(data);

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            return rpcResult.Result;
        }

        /// <summary>
        /// Creates new message call transaction or a contract creation, if the data field contains code.
        /// </summary>
        /// <param name="from">The address the transaction is send from.</param>
        /// <param name="to">(optional when creating new contract) The address the transaction is directed to.</param>
        /// <param name="gas">(optional, default: 90000) Integer of the gas provided for the transaction execution. It will return unused gas.</param>
        /// <param name="data">(optional) The compiled code of a contract</param>
        /// <param name="gasPrice">(optional, default: To-Be-Determined) Integer of the gasPrice used for each paid gas</param>
        /// <param name="value">(optional) Integer of the value send with this transaction</param>
        /// <param name="nonce">(optional) Integer of a nonce. This allows to overwrite your own pending transactions that use the same nonce.</param>
        /// <returns>the transaction hash, or the zero hash if the transaction is not yet available.</returns>
        public string SendTransaction(string from, string to, int gas, string data, int gasPrice = -1, int value = -1,  int nonce = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_sendTransaction);

            var transactionParams = new Transaction();
            transactionParams.From = from;
            transactionParams.To = to;
            transactionParams.Gas = gas.ToHexString();
            transactionParams.Data = data;

            if (gasPrice > -1)
                transactionParams.GasPrice = gas.ToHexString();

            if (value > -1)
                transactionParams.Value = value.ToHexString();

            if (nonce > -1)
                transactionParams.Nonce = nonce.ToHexString();

            rpcRequest.AddParam(transactionParams);

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            return rpcResult.Result;
        }

        /// <summary>
        /// Creates new message call transaction or a contract creation for signed transactions.
        /// </summary>
        /// <param name="data">The signed transaction data.</param>
        /// <returns> the transaction hash, or the zero hash if the transaction is not yet available.</returns>
        public string SendRawTransaction(string data)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_sendRawTransaction);

            rpcRequest.AddParam(new { data = data });
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            return rpcResult.Result;
        }

        public string Call(string from, string to, int gas, string data, int gasPrice = -1, int value = -1, int nonce = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_call);

            var transactionParams = new Transaction();
            transactionParams.From = from;
            transactionParams.To = to;
            transactionParams.Gas = gas.ToHexString();
            transactionParams.Data = data;

            if (gasPrice > -1)
                transactionParams.GasPrice = gas.ToHexString();

            if (value > -1)
                transactionParams.Value = value.ToHexString();

            if (nonce > -1)
                transactionParams.Nonce = nonce.ToHexString();

            rpcRequest.AddParam(transactionParams);

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            return rpcResult.Result;
        }

        public string EstimateGas()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_estimateGas);
            throw new Exception("not implemented");
            return string.Empty;
        }

        public Block GetBlockByHash(string hash,bool returnFullBlock)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getBlockByHash);
            rpcRequest.AddParam(hash);
            rpcRequest.AddParam(returnFullBlock);

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var json = JsonConvert.SerializeObject(rpcResult.Result);
            var block = JsonConvert.DeserializeObject<Block>(json);

            return block;
        }

        public Block GetBlockByNumber(int blockNumber, BlockTag blockTag, bool returnFullObject)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getBlockByNumber);

            if (blockTag != BlockTag.Quantity && blockNumber > -1)
            {
                throw new Exception("Balance tag and block number cannot both be provided, chose either");
            }

            if (blockTag != BlockTag.Quantity)
            {
                rpcRequest.AddParam(blockTag.ToJsonMethodName());
            }
            else
            {
                rpcRequest.AddParam(blockNumber.ToHexString());
            }

            rpcRequest.AddParam(returnFullObject);

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var json = JsonConvert.SerializeObject(rpcResult.Result);
            var block = JsonConvert.DeserializeObject<Block>(json);

            return block;
        }

        public Transaction GetTransactionByHash(string hash)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getTransactionByHash);
            rpcRequest.AddParam(hash);
            rpcRequest.AddParam("true");

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var json = JsonConvert.SerializeObject(rpcResult.Result);
            var tx = JsonConvert.DeserializeObject<Transaction>(json);

            return tx;
        }

        public Transaction GetTransactionByBlockHashAndIndex(string hash, int index)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getTransactionByBlockHashAndIndex);
            rpcRequest.AddParam(hash);
            rpcRequest.AddParam(index.ToHexString());

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var json = JsonConvert.SerializeObject(rpcResult.Result);
            var tx = JsonConvert.DeserializeObject<Transaction>(json);

            return tx;
        }

        public Transaction GetTransactionByBlockNumberAndIndex(int blockNumber, int index)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getTransactionByBlockNumberAndIndex);
            rpcRequest.AddParam(blockNumber.ToHexString());
            rpcRequest.AddParam(index.ToHexString());

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var json = JsonConvert.SerializeObject(rpcResult.Result);
            var tx = JsonConvert.DeserializeObject<Transaction>(json);

            return tx;
        }

        public Transaction GetTransactionReceipt(string transactionHash)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getTransactionReceipt);
            rpcRequest.AddParam(transactionHash);

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var json = JsonConvert.SerializeObject(rpcResult.Result);
            var tx = JsonConvert.DeserializeObject<Transaction>(json);

            return tx;
        }



        public Block GetUncleByBlockHashAndIndex(string hash, int index)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getUncleByBlockHashAndIndex);
            rpcRequest.AddParam(hash);
            rpcRequest.AddParam(index.ToHexString());

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var json = JsonConvert.SerializeObject(rpcResult.Result);
            var block = JsonConvert.DeserializeObject<Block>(json);

            return block;
        }

        public Block GetUncleByBlockNumberAndIndex(int blockNumber, int index)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getUncleByBlockNumberAndIndex);
            rpcRequest.AddParam(blockNumber.ToHexString());
            rpcRequest.AddParam(index.ToHexString());

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var json = JsonConvert.SerializeObject(rpcResult.Result);
            var block = JsonConvert.DeserializeObject<Block>(json);

            return block;
        }

        public string[] GetCompilers()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getCompilers);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            var compilerList = new List<string>();
            foreach (var account in rpcResult.Result)
            {
                compilerList.Add(account.Value);
            }

            return compilerList.ToArray();
        }

        public string CompileSolidity()
        {
            throw new Exception("not yet implemented");
        }

        public string CompileLLL()
        {
            throw new Exception("not yet implemented");
        }

        public string CompileSerpent()
        {
            throw new Exception("not yet implemented");
        }





    }
}
