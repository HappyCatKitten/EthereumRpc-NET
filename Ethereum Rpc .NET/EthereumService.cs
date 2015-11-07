using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc.RpcObjects;
using Newtonsoft.Json;

namespace EthereumRpc
{
    public class EthereumService
    {
        public string GetWeb3ClientVersion()
        {
            var rpcRequest = new RpcRequest(RpcMethod.web3_clientVersion);
            var rpcResult = RpcConnector.MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        public string GetWeb3Sha3(string value)
        {
            var rpcRequest = new RpcRequest(RpcMethod.web3_sha3);
            rpcRequest.AddParam(value);
            var rpcResult = RpcConnector.MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        public string GetNetVersion()
        {
            var rpcRequest = new RpcRequest(RpcMethod.net_version);
            var rpcResult = RpcConnector.MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        public bool GetNetListening()
        {
            var rpcRequest = new RpcRequest(RpcMethod.net_version);
            var rpcResult = RpcConnector.MakeRequest(rpcRequest);
            var isListening = Convert.ToBoolean(Int32.Parse(rpcResult.Result));
            return isListening;
        }

        public int GetNetPeerCount()
        {
            var rpcRequest = new RpcRequest(RpcMethod.net_peerCount);
            var rpcResult = RpcConnector.MakeRequest(rpcRequest);
            var peerCount = Convert.ToInt32(rpcResult.Result, 16);
            return peerCount;
        }

        public string GetEthProtocolVersion()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_protocolVersion);
            var rpcResult = RpcConnector.MakeRequest(rpcRequest);
            return rpcResult.Result;
        }

        public SyncStatus GetEthSyncing()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_syncing);
            var rpcResult = RpcConnector.MakeRequest(rpcRequest);
            var result = false;
            var isBoolean = Boolean.TryParse(rpcResult.Result, out result);
            if (!isBoolean)
            {
                var syncStatus = JsonConvert.DeserializeObject<SyncStatus>(rpcResult.Result);
                return syncStatus;
            }

            return null;
        }

        public Address GetEthCoinbase()
        {
            var rpcRequest = new RpcRequest(RpcMethod.eth_coinbase);
            var rpcResult = RpcConnector.MakeRequest(rpcRequest);
            var address = new Address(rpcResult.Result);
            return address;
        }
        
    }
}
