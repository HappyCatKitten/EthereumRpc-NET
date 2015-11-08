using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc;

namespace Ethereum_Rpc.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new Connection();
            connection.Port = "8545";
            connection.Url = "http://localhost";
            connection.Proxy = new WebProxy();

            var ethereumService = new EthereumService(connection);

            Console.WriteLine(ethereumService.GetWeb3ClientVersion());
            //Console.WriteLine(ethereumService.GetWeb3Sha3("Hello world"));
            //Console.WriteLine(ethereumService.GetNetVersion());
            //Console.WriteLine(ethereumService.GetNetListening());
            //Console.WriteLine(ethereumService.GetNetPeerCount());
            //Console.WriteLine(ethereumService.GetEthProtocolVersion());
            //Console.WriteLine(ethereumService.GetEthSyncing());
            //Console.WriteLine(ethereumService.GetEthCoinbase().Value);
            //Console.WriteLine(ethereumService.GetEthMining());
            //Console.WriteLine(ethereumService.GetEthHashrate());
            //Console.WriteLine(ethereumService.GetEthGasPrice());
            //ethereumService.GetEthAccounts().ToList().ForEach(i => Console.Write(@"[{0}] ", i));
            //Console.WriteLine(ethereumService.GetEthBlockNumber());
            //Console.WriteLine(ethereumService.GetEthGetBalance("0x407d73d8a49eeb85d32cf465507dd71d507100c1", BlockParam.Latest));
            //Console.WriteLine(ethereumService.GetEthGetStorageAt("0x407d73d8a49eeb85d32cf465507dd71d507100c1",100, BlockParam.Latest));
            //Console.WriteLine(ethereumService.GetEthGetTransactionCount("0x407d73d8a49eeb85d32cf465507dd71d507100c1", BlockParam.Latest));
            //Console.WriteLine(ethereumService.GetEthGetBlockTransactionCountByHash("0xb903239f8543d04b5dc1ba6579132b143087c68db1b2168786408fcbce568238")); // this returns null

            



            Console.ReadLine();
        }
    }
}
