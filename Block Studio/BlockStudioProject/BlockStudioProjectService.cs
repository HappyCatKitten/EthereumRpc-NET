using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.CustomControls;
using BlockStudio.Ethereum;
using BlockStudio.HtmlGenerator;
using BlockStudio.Project;
using BlockStudio.Settings;
using BlockStudio.TreeNodes;
using EthereumRpc;
using EthereumRpc.RpcObjects;

namespace BlockStudio.Project
{
    public class BlockStudioProjectService
    {
        public static BlockStudioProject BlockStudioProject { get; set; }

        public static BlockStudioSettings BlockStudioSettings { get; set; }

        private readonly TreeView _fileTreeView;

        private readonly TextBox _txtEstimatedGas;

        private readonly TextBox _txtConsoleOut;

        private readonly FlowLayoutPanel _fpAbi;

        public static string SolcOutputPath { get; set; }

        public string PublishedTxHash{ get; set; }

        public static Transaction TransactionReceipt { get; set; }


        public BlockStudioProjectService(TreeView treeview, FlowLayoutPanel fpAbi, TextBox txtEstimatedGas,TextBox txtConsoleOut)
        {
            _txtEstimatedGas = txtEstimatedGas;
            _fpAbi = fpAbi;
            _fileTreeView = treeview;
            _txtConsoleOut = txtConsoleOut;

            SolcOutputPath = string.Format(@"{0}contract", BlockStudioProject.SaveFolder);
            if (!Directory.Exists(SolcOutputPath))
            {
                Directory.CreateDirectory(SolcOutputPath);
            }
            
            var watcher = new FileSystemWatcher(SolcOutputPath);
            watcher.Created += Watcher_Created;
            watcher.EnableRaisingEvents = true;

            BlockStudioSettings = BlockStudioSettings.Load();
        }

        public void EstimateGas()
        {
            var account = BlockStudioProject.DefaultAccount;

            var bin = GetFile(SolcProjectFileType.Bin);

            var transaction = new Transaction()
            {
                From = account.Address,
                Data = bin.Value
            };

            var estimatedGas = BlockStudioProject.Connection.EthereumService.EstimateGas(transaction);
            _txtEstimatedGas.Text = estimatedGas.ToString();
        }

        public SolcProjectFile GetFile(SolcProjectFileType solcProjectFileType)
        {
            var file = BlockStudioProject.SolcProjectFiles.FirstOrDefault(x => x.SolcProjectFileType == solcProjectFileType);
            return file;
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            _fileTreeView.BeginInvoke((MethodInvoker)delegate
            {
                var solcProjectFileType = SolcProjectFileType.Sol;

                var fileInfo = new FileInfo(e.FullPath);

                switch (fileInfo.Extension)
                {
                    case ".abi":
                        solcProjectFileType = SolcProjectFileType.Abi;
                        break;
                    case ".bin":
                        solcProjectFileType = SolcProjectFileType.Bin;
                        break;
                    case ".sol":
                        solcProjectFileType = SolcProjectFileType.Sol;
                        break;
                }

                
                AddFile(fileInfo, solcProjectFileType);

                TreeNodeManager.UpsertSolcFiles();
                HtmlTabManager.RefreshHtmlEditor();

                if (solcProjectFileType== SolcProjectFileType.Abi)
                {
                    var abiFile = GetFile(SolcProjectFileType.Abi);

                    if (abiFile != null)
                    {
                        _fpAbi.Controls.Clear();
                        var abiDef = abiFile.AbiDefinition;
                        
                        var functions = abiDef.Where(x => x.Type == "function");
                        foreach (var function in functions)
                        {
                            var ethFunction = new EthFunction(function,_txtConsoleOut);
                            _fpAbi.Controls.Add(ethFunction);
                            ethFunction.Width = _fpAbi.Width-10;
                        }

                        
                    }
                    else
                    {
                        //MessageBox.Show("Doesnt exist");
                    }

                }
                else if (solcProjectFileType == SolcProjectFileType.Bin)
                {
                    EstimateGas();
                }
            });

        }

        public string WaitForFile(FileInfo fileInfo)
        {
            for (var numTries = 0; numTries < 25; numTries++)
            {
                try
                {
                    var value = File.ReadAllText(fileInfo.FullName);
                    return value;
                }
                catch (IOException)
                {
                    Thread.Sleep(50);
                }
            }

            return null;
        }

        public void AddFile(FileInfo fileInfo, SolcProjectFileType solcProjectFileType)
        {
            var exists = GetFile(solcProjectFileType);
            if (exists!=null)
            {
                BlockStudioProject.SolcProjectFiles.Remove(exists);
            }

            var solcProjectFile = new SolcProjectFile
            {
                SolcProjectFileType = solcProjectFileType,
                FileName = fileInfo.Name,
                FilePath = fileInfo.FullName,
                Value = WaitForFile(fileInfo)
            };

            BlockStudioProject.SolcProjectFiles.Add(solcProjectFile);
        }
    }
}
