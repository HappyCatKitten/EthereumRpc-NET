using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc;

namespace Ethereum_Rpc.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            var ethereumService = new EthereumService();

            //Console.WriteLine(ethereumService.GetWeb3ClientVersion());
            //Console.WriteLine(ethereumService.GetWeb3Sha3("Hello world"));
            //Console.WriteLine(ethereumService.GetNetVersion());
            //Console.WriteLine(ethereumService.GetNetListening());
            //Console.WriteLine(ethereumService.GetNetPeerCount());
            //Console.WriteLine(ethereumService.GetEthProtocolVersion());

            // Console.WriteLine(ethereumService.GetEthSyncing());
            Console.WriteLine(ethereumService.GetEthCoinbase());

            Console.ReadLine();
        }
    }
}
