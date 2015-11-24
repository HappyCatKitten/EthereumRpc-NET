using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BlockStudio.Persistant;

namespace BlockStudio.Ethereum
{
    public class GethService
    {
        public static string PathLocation => System.Reflection.Assembly.GetExecutingAssembly().Location;

        public static string ExecutingFolder
        {
            get
            {
                var fileInfo = new FileInfo(PathLocation);
                return fileInfo.DirectoryName+ "\\";
            }
        }

        public static void RunGethInstance(Connection connection)
        {
            var fileInfo = new FileInfo(PathLocation);
            var gethPath = string.Format("{0}\\geth.exe", fileInfo.DirectoryName);
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = gethPath;

            if (!File.Exists(connection.PrivateChainPath))
            {
                Directory.CreateDirectory(connection.PrivateChainPath);
            }

            var args = string.Empty;

            var argsWorking =
             @" --genesis ""C:/Users/machine/Dropbox/Ethereum/Geth/genesis.js"" --datadir ""C:/Users/machine/Dropbox/Ethereum/Geth/privatechain/"" --networkid 123 --mine --nodiscover --maxpeers 0 --rpc --rpcaddr=""0.0.0.0"" --rpcapi ""eth,web3,personal"" --minerthreads ""1"" --rpcport=8545 --rpccorsdomain *";

            if (connection.PrivateChain)
            {
                args = string.Format(@" --genesis ""C:/Users/machine/Dropbox/Ethereum/Geth/genesis.js"" --datadir ""C:/Users/machine/Dropbox/Ethereum/Geth/privatechain/"" --networkid {0} --mine --nodiscover --maxpeers 0 --rpc --rpcaddr=""0.0.0.0"" --rpcapi ""eth,web3,personal"" --minerthreads ""1"" --rpcport={1} --rpccorsdomain *",
                connection.NetworkId,
                connection.Port);
            }
            else
            {
                args = string.Format(@" --rpc --rpcaddr=""0.0.0.0"" --rpcapi ""eth,web3,personal"" --rpcport={0} --rpccorsdomain *",
                connection.Port);
            }


            startInfo.Arguments = args;
            Process.Start(startInfo);
        }
    }
}
