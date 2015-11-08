using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc.RpcObjects;
using Newtonsoft.Json;

namespace EthereumRpc
{
    public class EthereumService
    {
        public EthereumService(string url, string port)
        {
            RpcConnector.Connection = new Connection();
            RpcConnector.Connection.Url = url;
            RpcConnector.Connection.Port = port;
        }

        public EthereumService(Connection connection)
        {
            RpcConnector.Connection = connection;
        }

        public EthereumService()
        {
            if (RpcConnector.Connection == null)
            {
                RpcConnector.Connection = new Connection();
                var urlString = ConfigurationManager.AppSettings["EthereumRpcUrl"];
                var portString = ConfigurationManager.AppSettings["EthereumRpcPort"];

                RpcConnector.Connection.Url = urlString;
                RpcConnector.Connection.Port = portString;
            }
        }

        public string GetWeb3ClientVersion()
        {
            var rpcRequest = new RpcRequest(RpcMethod.web3_clientVersion);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        public string GetWeb3Sha3(string value)
        {
            var rpcRequest = new RpcRequest(RpcMethod.web3_sha3);
            rpcRequest.AddParam(value);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        public string GetNetVersion()
        {
            var rpcRequest = new RpcRequest(RpcMethod.net_version);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        public bool GetNetListening()
        {
            var rpcRequest = new RpcRequest(RpcMethod.net_version);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var isListening = Convert.ToBoolean(Int32.Parse(rpcResult.Result));
            return isListening;
        }

        public int GetNetPeerCount()
        {
            var rpcRequest = new RpcRequest(RpcMethod.net_peerCount);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var peerCount = Convert.ToInt32(rpcResult.Result, 16);
            return peerCount;
        }

        public string GetEthProtocolVersion()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_protocolVersion);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        public SyncStatus GetEthSyncing()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_syncing);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            
            if (rpcResult.Result.GetType()!=typeof(Boolean))
            {
                var syncStatus = JsonConvert.DeserializeObject<SyncStatus>(rpcResult.Result);
                return syncStatus;
            }

            return null;
        }

        public Address GetEthCoinbase()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_coinbase);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var address = new Address(rpcResult.Result);
            return address;
        }

        public bool GetEthMining()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_mining);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);

            return rpcResult.Result;
        }

        public long GetEthHashrate()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_hashrate);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var hashRate = Convert.ToInt64(rpcResult.Result, 16);

            return hashRate;
        }

        public long GetEthGasPrice()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_gasPrice);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var gasPrice = Convert.ToInt64(rpcResult.Result, 16);

            return gasPrice;
        }

        public string[] GetEthAccounts()
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

        public long GetEthBlockNumber()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_blockNumber);
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var ethBlockNumber = Convert.ToInt64(rpcResult.Result, 16);

            return ethBlockNumber;
        }

        public long GetEthGetBalance(string address, BlockParam blockParam = BlockParam.Nothing, int blockNumber = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getBalance);

            rpcRequest.AddParam(address);

            if (blockParam != BlockParam.Nothing && blockNumber > -1)
            {
                throw new Exception("Balance tag and block number cannot both be provided, chose either");
            }

            if (blockParam != BlockParam.Nothing)
            {
                rpcRequest.AddParam(blockParam.ToJsonMethodName());
            }
            else
            {
                rpcRequest.AddParam(blockNumber.ToString());
            }

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var balance = Convert.ToInt64(rpcResult.Result, 16);

            return balance;
        }

        public long GetEthGetStorageAt(string address,int storagePosition, BlockParam blockParam = BlockParam.Nothing, int blockNumber = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getStorageAt);

            rpcRequest.AddParam(address);
            rpcRequest.AddParam(storagePosition.ToString());

            if (blockParam != BlockParam.Nothing && blockNumber > -1)
            {
                throw new Exception("Balance tag and block number cannot both be provided, chose either");
            }

            if (blockParam != BlockParam.Nothing)
            {
                rpcRequest.AddParam(blockParam.ToJsonMethodName());
            }
            else
            {
                rpcRequest.AddParam(blockNumber.ToString());
            }

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var balance = Convert.ToInt64(rpcResult.Result, 16);

            return balance;
        }

        public long GetEthGetTransactionCount(string address, BlockParam blockParam = BlockParam.Nothing, int blockNumber = -1)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getTransactionCount);

            rpcRequest.AddParam(address);

            if (blockParam != BlockParam.Nothing && blockNumber > -1)
            {
                throw new Exception("Balance tag and block number cannot both be provided, chose either");
            }

            if (blockParam != BlockParam.Nothing)
            {
                rpcRequest.AddParam(blockParam.ToJsonMethodName());
            }
            else
            {
                rpcRequest.AddParam(blockNumber.ToString());
            }

            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var balance = Convert.ToInt64(rpcResult.Result, 16);

            return balance;
        }

        public long GetEthGetBlockTransactionCountByHash(string blockHash)
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_getBlockTransactionCountByHash);
            //todo validate the 20 byte block hash
            rpcRequest.AddParam(blockHash);
            rpcRequest.Id = 1;
            var rpcResult = new RpcConnector().MakeRequest(rpcRequest);
            var count = Convert.ToInt64(rpcResult.Result, 16);

            return count;
        }

        


    }
}
