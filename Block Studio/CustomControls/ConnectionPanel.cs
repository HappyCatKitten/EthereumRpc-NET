using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.Ethereum;
using Ethereum.Wallet.Persistant;
using EthereumRpc;
using EthereumRpc.RpcObjects;

namespace BlockStudio.CustomControls
{
    public partial class ConnectionPanel : UserControl
    {
        public SavedConnection SavedConnection{ get; set; }
        public EthereumService EthereumService { get; set; }
        private bool _isSyncing = false;

        public ConnectionPanel(SavedConnection savedConnection)
        {
            SavedConnection = savedConnection;
            EthereumService = new EthereumService(SavedConnection.Url,SavedConnection.Port);

            InitializeComponent();

            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerAsync();
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                SyncStatus syncStatus = null;
                try
                {
                    syncStatus = EthereumService.GetSyncing();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var value = txtSearch.Text;

            try
            {
                var block = EthereumService.GetBlockByHash(value, false);
                txtResults.Text = block.Hash;
                return;
            }
            catch (Exception)
            {

            }

            try
            {
                var tx = EthereumService.GetTransactionByHash(value);
                txtResults.Text = tx.Hash;
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GethService.RunGethInstance(new SavedConnection() {Port = "8555"});

        }


    }
}
