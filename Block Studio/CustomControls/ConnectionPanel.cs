using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.Dialogs;
using BlockStudio.Ethereum;
using BlockStudio.Ethereum.Filter;
using BlockStudio.Project;
using BlockStudio.Html;
using BlockStudio.TreeNodes;
using ColorCode;
using EthereumRpc;
using EthereumRpc.Ethereum.AbiDefinition;
using EthereumRpc.RpcObjects;
using FastColoredTextBoxNS;

namespace BlockStudio.CustomControls
{
    public partial class ConnectionPanel : UserControl
    {
        public BlockStudioProjectService BlockStudioProjectService { get; set; }

        private TextStyle _style = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        private bool _isSyncing = false;

        private EthereumFilterManager _ethereumFilterManager;

        public ConnectionPanel()
        {
            InitializeComponent();
        }

        public void BindControls()
        {
            tabBlockchain.Enabled = false;
            fsSource.Language = Language.Custom;
            fsSource.TextChanged += FsSource_TextChanged;

            var remember = fsSource.Text;
            fsSource.Text = string.Empty;
            fsSource.Text = remember;

            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerAsync();

            BlockStudioProjectService = new BlockStudioProjectService(tvFiles, fpAbi, txtEstimateGas, txtBuildOutput);
            _ethereumFilterManager = new EthereumFilterManager(txtBuildOutput);

            RefreshAccounts();
        }


        private void FsSource_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle();
            e.ChangedRange.SetStyle(_style, @"^(?<range>[\w\s]+\b(function|contract|return|string|uint|bytes|bytes32)\s+[\w<>,\s]+)|^\s*(function|contract|return|string|uint|bytes|bytes32)[^\n]+(\n?\s*{|;)?");
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                return;
                SyncStatus syncStatus = null;
                try
                {
                    syncStatus = BlockStudioProjectService.BlockStudioProject.Connection.EthereumService.GetSyncing();
                }
                catch (Exception)
                {
                    BeginInvoke((MethodInvoker) delegate
                    {
                        lblBlockChainStatus.Text = "No instance running";
                    });

                    Thread.Sleep(500);
                    continue;
                }

                BeginInvoke((MethodInvoker) delegate
                {
                    if (_isSyncing != syncStatus.IsSyncing)
                    {
                        if (syncStatus.IsSyncing)
                        {
                            var totalBlocks = syncStatus.HighestBlock.HexToInt();
                            pbBlockChainSyncing.Maximum = totalBlocks;
                            pbBlockChainSyncing.Style = ProgressBarStyle.Blocks;
                            lblBlockChainStatus.Text = "Syncing blockchain";
                        }
                        else
                        {
                            pbBlockChainSyncing.Style = ProgressBarStyle.Continuous;
                            pbBlockChainSyncing.Step = 100;
                            lblBlockChainStatus.Text = "Blockchain up to date";
                        }

                        _isSyncing = syncStatus.IsSyncing;
                    }

                    if (syncStatus.IsSyncing)
                    {
                        var totalBlocks = syncStatus.HighestBlock.HexToInt();
                        var blocksCompleted = syncStatus.CurrentBlock.HexToInt();
                        var blocksRemaining = (totalBlocks-1) - blocksCompleted;

                        var step = blocksCompleted - pbBlockChainSyncing.Value;
                        pbBlockChainSyncing.Step = step;
                        pbBlockChainSyncing.PerformStep();
                        lblBlockChainStatus.Text = string.Format("Syncing blockchain, {0} blocks remaining",
                            blocksRemaining.ToString("N0"));
                    }
                    else
                    {
                        pbBlockChainSyncing.Maximum = 100;
                        pbBlockChainSyncing.Step = 100;
                        pbBlockChainSyncing.PerformStep();
                        lblBlockChainStatus.Text = "Blockchain up to date";
                    }
                });

                Thread.Sleep(200);
            }
        }

     

        private void btnBuild_Click(object sender, EventArgs e)
        {
            Build();
        }

        private void Build()
        {
            var files = Directory.GetFiles(BlockStudioProjectService.SolcOutputPath);
            foreach (var file in files)
            {
                File.Delete(file);
            }

            tvFiles.Nodes.Clear();

            var x = BlockStudioProjectService.BlockStudioProject.Connection.EthereumService.CompileSolidity(fsSource.Text);

            SolcService.Compile(fsSource.Text);


            tabBlockchain.Enabled = true;
            

            //var result = _connection.EthereumService.CompileSolidity(txtSource.Text);
        }


        private void btnRefreshAddressList_Click(object sender, EventArgs e)
        {
            RefreshAccounts();
        }

        private void RefreshAccounts()
        {
            cmbAccounts.Items.Clear();
            foreach (var account in BlockStudioProjectService.BlockStudioProject.Accounts)
            {
                //account.ToStringValue = String.Format("{0} - {1} Eth", account.Label, account.BalanceEther);
                cmbAccounts.Items.Add(account);
            }

            if (cmbAccounts.Items.Count > 0)
            {
                cmbAccounts.SelectedIndex = 0;
            }
        }


        private void fsSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.B)
            {
                Build();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAccounts();
        }


        private void btnPublish_Click(object sender, EventArgs e)
        {
            var accountValue = cmbAccounts.SelectedItem;
            if (accountValue == null)
            {
                var result = MessageBoxEx.Show(this, string.Format("Select an account to publish from"), "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var account = (Account) accountValue;

            if (account.Balance < 10000000)
            {
                var result = MessageBoxEx.Show(this, string.Format("You do not have enough Ether to publish the contract"), "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var bin = BlockStudioProjectService.GetFile(SolcProjectFileType.Bin);

            if (bin==null)
            {
                var result = MessageBoxEx.Show(this, string.Format("It appears there is no bytecode generated for this project"), "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var transaction = new Transaction()
            {
                From = account.Address,
                Data = bin.Value,
                Gas = txtEstimateGas.Text 
            };

            BlockStudioProjectService.PublishedTxHash = BlockStudioProjectService.BlockStudioProject.Connection.EthereumService.SendTransaction(transaction);
            _ethereumFilterManager.AddBlockPendingFilter(BlockStudioProjectService.PublishedTxHash);
            _ethereumFilterManager.Start();
            txtBuildOutput.WriteConsonsoleMessage("contract published with code: {0}", BlockStudioProjectService.GetFile(SolcProjectFileType.Bin).Value);
      
        }

        private void cmbAccounts_SelectedValueChanged(object sender, EventArgs e)
        {
            var account = (Account)cmbAccounts.SelectedItem;
            BlockStudioProjectService.BlockStudioProject.DefaultAccount = account;
        }

        private void btnGetCode_Click(object sender, EventArgs e)
        {
            var tx = BlockStudioProjectService.TransactionReceipt;
            if (tx == null)
            {
                MessageBox.Show("No transaction");
            }

           var code = BlockStudioProjectService.BlockStudioProject.Connection.EthereumService.GetCode(tx.ContractAddress,BlockTag.Latest);

           txtBuildOutput.WriteConsonsoleMessage("Code : {0}", code);
        }

    }
}
