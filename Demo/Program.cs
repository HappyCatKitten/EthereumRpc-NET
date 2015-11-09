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

            var exampleTxHash = "0x79b636e7a28e74b6d1db3be815e2658c759dd3213605ca7916b3a19402d0ba42";
            var exampleBlockHash = "0xca3130089dca52a645b1545a0f04930257dea601b54011aececd616d04fec12f";
            var exampleBlockNumber = 514064;
            var exampleAddress = "0x63a9975ba31b0b9626b34300f7f627147df1f526";

            //Console.WriteLine(ethereumService.GetWeb3ClientVersion());
            //Console.WriteLine(ethereumService.GetWeb3Sha3("Hello world"));
            //Console.WriteLine(ethereumService.GetNetVersion());
            //Console.WriteLine(ethereumService.GetNetListening());
            //Console.WriteLine(ethereumService.GetNetPeerCount());
            //Console.WriteLine(ethereumService.GetProtocolVersion());
            //Console.WriteLine(ethereumService.GetSyncing());
            //Console.WriteLine(ethereumService.GetCoinbase().Value);
            //Console.WriteLine(ethereumService.GetMining());
            //Console.WriteLine(ethereumService.GetHashrate());
            //Console.WriteLine(ethereumService.GetGasPrice());
            //ethereumService.GetAccounts().ToList().ForEach(i => Console.Write(@"[{0}] ", i));
            //Console.WriteLine(ethereumService.GetBlockNumber());
            //Console.WriteLine(ethereumService.GetBalance(exampleAddress, BlockTag.Latest));
            //Console.WriteLine(ethereumService.GetStorageAt(exampleAddress, 100, BlockTag.Latest));
            //Console.WriteLine(ethereumService.GetTransactionCount(exampleAddress, BlockTag.Latest));
            //Console.WriteLine(ethereumService.GetBlockTransactionCountByHash(exampleBlockHash)); 
            //Console.WriteLine(ethereumService.GetBlockTransactionCountByNumber(BlockTag.Latest));
            //Console.WriteLine(ethereumService.GetUncleCountByBlockHash(exampleBlockHash));
            //Console.WriteLine(ethereumService.GetUncleCountByBlockNumber(10));
            //Console.WriteLine(ethereumService.GetCode("0xa94f5374fce5edbc8e2a8697c15331677e6ebf0b", BlockTag.Latest));


            //Console.WriteLine(ethereumService.Sign("0xd1ade25ccd3d550a7eb532ac759cac7be09c2719", "School bus")); // return nothing
            //Console.WriteLine(ethereumService.SendTransaction("0xb60e8dd61c5d32be8058bb8eb970870f07233155", "0xd46e8dd67c5d32be8058bb8eb970870f072445675", 30400, "0xd46e8dd67c5d32be8d46e8dd67c5d32be8058bb8eb970870f072445675058bb8eb970870f072445675")); //return nothing
            //Console.WriteLine(ethereumService.SendRawTransaction("0xd46e8dd67c5d32be8d46e8dd67c5d32be8058bb8eb970870f072445675058bb8eb970870f072445675")); // returns nothing
            //Console.WriteLine(ethereumService.Call("0xb60e8dd61c5d32be8058bb8eb970870f07233155", "0xd46e8dd67c5d32be8058bb8eb970870f072445675", 30400, "0xd46e8dd67c5d32be8d46e8dd67c5d32be8058bb8eb970870f072445675058bb8eb970870f072445675")); //return nothing

            //Console.WriteLine(ethereumService.EstimateGas()); // not yet implemented
            //Console.WriteLine(ethereumService.GetBlockByHash(exampleBlockHash, true)); // works but need to fix partial value return (fullblock:false)
            //Console.WriteLine(ethereumService.GetBlockByNumber(exampleBlockNumber, BlockTag.Quantity,true));
            //Console.WriteLine(ethereumService.GetTransactionByHash(exampleTxHash));


            //Console.WriteLine(ethereumService.GetTransactionByBlockHashAndIndex(exampleBlockHash,0));
            //Console.WriteLine(ethereumService.GetTransactionByBlockNumberAndIndex(exampleBlockNumber, 0));
            //Console.WriteLine(ethereumService.GetTransactionReceipt(exampleTxHash));
            //Console.WriteLine(ethereumService.GetUncleByBlockHashAndIndex(exampleBlockHash,0)); // doesnt seem to return the uncle
            //Console.WriteLine(ethereumService.GetUncleByBlockNumberAndIndex(exampleBlockNumber, 0)); // doesnt seem to return the uncle

            //ethereumService.GetCompilers().ToList().ForEach(i => Console.Write(@"[{0}] ", i));

            //Console.WriteLine(ethereumService.CompileSolidity()); //not yet implemented
            //Console.WriteLine(ethereumService.CompileLLL()); //not yet implemented
            //Console.WriteLine(ethereumService.CompileSerpent()); //not yet implemented

            Console.ReadLine();
        }
    }
}
