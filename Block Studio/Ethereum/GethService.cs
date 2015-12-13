using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using BlockStudio.Project;
using BlockStudio.Settings;

namespace BlockStudio.Ethereum
{
    public class GethService
    {
        public static string WhatsRunningOnPort(string port)
        {
            //var portValue = Int32.Parse(port);
            //IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();

            //IPEndPoint[] endPoints = ipProperties.GetActiveTcpListeners();
            //TcpConnectionInformation[] tcpConnections =
            //    ipProperties.GetActiveTcpConnections();

            //foreach (TcpConnectionInformation info in tcpConnections)
            //{
            //    if(portValue==)
            //    Console.WriteLine("Local: {0}:{1}\nRemote: {2}:{3}\nState: {4}\n",
            //        info.LocalEndPoint.Address, info.LocalEndPoint.Port,
            //        info.RemoteEndPoint.Address, info.RemoteEndPoint.Port,
            //        info.State.ToString());
            //}
            //Console.ReadLine();

            return "";
        }
        public static GethInstanceState GetPortAndInstanceUse(string port)
        {
            var portValue = Int32.Parse(port);
            var portAvailable = true;

            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            foreach (var tcpi in tcpConnInfoArray)
            {
                if (tcpi.LocalEndPoint.Port == portValue)
                {
                    portAvailable = false;
                    break;
                }
            }

            //var processes = Process.GetProcessesByName("geth");
            //if (processes.Length > 0)
            //{
                
            //    return GethInstanceState.InstanceRunning;
            //}

            if (portAvailable)
            {
                return GethInstanceState.NoInstanceRunning;
            }
            else
            {
                return GethInstanceState.InstanceRunning;
            }
        }


        

        public static string ExecutingFolder
        {
            get
            {
                var fileInfo = new FileInfo(BlockStudioSettings.ExecutingDirectory);
                return fileInfo.DirectoryName+ "\\";
            }
        }

        public static string GetCommandLineArgs(Connection connection)
        {
            var args = string.Empty;

            //var solc = "C:/Program Files/Ethereum (++) 0.9.34/Release/solc.exe";
            var solc = "C:/Program Files/Ethereum 1.0.0/Release/solc.exe";

            if (connection.PrivateChain)
            {
                
                //args = string.Format(@" --genesis ""C:/Users/machine/Dropbox/Ethereum/Geth/genesis.js"" --datadir ""C:/Users/machine/Dropbox/Ethereum/Geth/privatechain/"" --networkid {0} --mine --port {1} --nodiscover --maxpeers 0 --rpc --rpcaddr=""0.0.0.0"" --rpcapi ""eth,web3,personal"" --minerthreads ""1"" --rpcport={2} --rpccorsdomain *",
                args = string.Format(@" --genesis ""C:/Users/machine/Dropbox/Ethereum/Geth/genesis.js"" --datadir ""C:/Users/machine/Dropbox/Ethereum/Geth/privatechain/"" --networkid {1} --port {2} --nodiscover --maxpeers 0 --rpc --rpcaddr=""0.0.0.0"" --rpcapi ""eth,web3,personal"" --minerthreads ""1"" --rpcport={3} --ipcpath ""{4}""  --solc ""{5}"" {6} --rpccorsdomain *",
                connection.DataDir.Replace(@"\\", "/"),
                connection.NetworkId,
                connection.Port,
                connection.RpcPort,
                connection.IpcPath,
                solc,
                connection.Mine ? "--mine" : string.Empty);
            }
            else
            {
                //args = string.Format(@" --rpc --rpcaddr=""0.0.0.0"" --rpcapi ""eth,web3,personal"" --networkid {0} --mine --port {1} --rpcport={2} --rpccorsdomain *",
                args = string.Format(@" --rpc --rpcaddr=""0.0.0.0"" --rpcapi ""eth,web3,personal"" --networkid {0} --port {1} --rpcport={2} --ipcpath ""{3}"" {4} --solc ""{5}"" --rpccorsdomain *",
                connection.NetworkId,
                connection.Port,
                connection.RpcPort,
                connection.IpcPath,
                connection.Mine ? "--mine" : string.Empty,
                solc);
            }

           

            //args = @" --genesis ""C:/Users/machine/Dropbox/Ethereum/Geth/genesis.js"" --datadir ""C:/Users/machine/Dropbox/Ethereum/Geth/privatechain/"" --networkid 123 --mine --nodiscover --maxpeers 0 --rpc --rpcaddr=""0.0.0.0"" --rpcapi ""eth,web3,personal"" --minerthreads ""1"" --rpcport=8545 --rpccorsdomain *";


            return args;

        }

        public static void RunGethInstance(Connection connection, bool isTest = false)
        {
            var args = GetCommandLineArgs(connection);

            if (isTest)
            {
                var startInfoTest = new ProcessStartInfo("cmd");
                startInfoTest.Arguments = @"/K C:\Users\machine\Dropbox\GitHub\""Ethereum Rpc .NET""\""Block Studio""\bin\Debug\geth.exe  " + args;
                //startInfoTest.RedirectStandardOutput = true;
                //startInfoTest.UseShellExecute = false;
                var process = new Process();
                process.StartInfo = startInfoTest;
                process.Start();
            }
            else
            {
                var gethPath = string.Format("{0}\\geth.exe", BlockStudioSettings.ExecutingDirectory);
                var startInfo = new ProcessStartInfo();
                //startInfo.RedirectStandardOutput = true;
                //startInfo.UseShellExecute = false;
                startInfo.FileName = gethPath;
                startInfo.Arguments = GetCommandLineArgs(connection);

                var process = new Process();
                process.StartInfo = startInfo;
                process.Start();
            }
        }
    }
}
