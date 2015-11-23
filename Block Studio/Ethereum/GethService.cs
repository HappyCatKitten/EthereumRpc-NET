using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ethereum.Wallet.Persistant;

namespace BlockStudio.Ethereum
{
    public class GethService
    {
        public static string PathLocation => System.Reflection.Assembly.GetExecutingAssembly().Location;

        public static void RunGethInstance(SavedConnection savedConnection)
        {
            var fileInfo = new FileInfo(PathLocation);
            var gethPath = string.Format("{0}\\geth.exe", fileInfo.DirectoryName);
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = gethPath;
            startInfo.Arguments = String.Format(@" --rpc --rpcaddr=""0.0.0.0"" --rpcport={0} --rpccorsdomain *",savedConnection.Port);
            Process.Start(startInfo);
        }
    }
}
