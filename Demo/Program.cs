using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new ConnectionOptions();
            connection.Port = "8545";
            connection.Url = "http://localhost";
            connection.Proxy = new WebProxy();

            var ethereumService = new EthereumService(connection);

            //Console.WriteLine(ethereumService.GetWeb3ClientVersion());
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
            //Console.WriteLine(ethereumService.GetEthGetBalance("0x407d73d8a49eeb85d32cf465507dd71d507100c1", BlockTag.Latest));
            //Console.WriteLine(ethereumService.GetEthGetStorageAt("0x407d73d8a49eeb85d32cf465507dd71d507100c1",100, BlockTag.Latest));
            //Console.WriteLine(ethereumService.GetEthGetTransactionCount("0x407d73d8a49eeb85d32cf465507dd71d507100c1", BlockTag.Latest));
            //Console.WriteLine(ethereumService.GetEthGetBlockTransactionCountByHash("0xb903239f8543d04b5dc1ba6579132b143087c68db1b2168786408fcbce568238")); // this returns null
            //Console.WriteLine(ethereumService.GetEthGetBlockTransactionCountByNumber(BlockTag.Latest));
            //Console.WriteLine(ethereumService.GetEthGetUncleCountByBlockHash("0xb903239f8543d04b5dc1ba6579132b143087c68db1b2168786408fcbce568238")); // this returns null
            //Console.WriteLine(ethereumService.GetEthEetUncleCountByBlockNumber(10));
            //Console.WriteLine(ethereumService.GetEthGetCode("0xa94f5374fce5edbc8e2a8697c15331677e6ebf0b",quanity:2));
            //Console.WriteLine(ethereumService.GetEthSign("0xd1ade25ccd3d550a7eb532ac759cac7be09c2719","School bus")); // return nothing
            //Console.WriteLine(ethereumService.GetEthSendTransaction("0xb60e8dd61c5d32be8058bb8eb970870f07233155", "0xd46e8dd67c5d32be8058bb8eb970870f072445675",30400, "0xd46e8dd67c5d32be8d46e8dd67c5d32be8058bb8eb970870f072445675058bb8eb970870f072445675")); //return nothing
            //Console.WriteLine(ethereumService.GethSendRawTransaction("0xd46e8dd67c5d32be8d46e8dd67c5d32be8058bb8eb970870f072445675058bb8eb970870f072445675")); // returns nothing



            //Console.WriteLine(ethereumService.GetEthEstimateGas()); // not yet implemented
            //Console.WriteLine(ethereumService.GetEthGetBlockByHash()); // not yet implemented


            Console.WriteLine(ethereumService.GetEthGetBlockByNumber(100,BlockTag.Quantity,true));
            

            Console.ReadLine();
        }
    }
}
