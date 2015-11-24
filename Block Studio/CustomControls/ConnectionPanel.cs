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
using BlockStudio.Dialogs;
using BlockStudio.Ethereum;
using BlockStudio.Html;
using BlockStudio.Persistant;
using EthereumRpc;
using EthereumRpc.RpcObjects;

namespace BlockStudio.CustomControls
{
    public partial class ConnectionPanel : UserControl
    {
        public Connection Connection{ get; set; }

        private bool _isSyncing = false;

        public ConnectionPanel(Connection connection)
        {
            Connection = connection;
            

            InitializeComponent();


            WebBrowserSettings.Mute();

            var browserScriptInterface = new BrowserScriptInterface();
            browserScriptInterface.WebBrowser = webBrowser1;
            browserScriptInterface.EthereumService = Connection.EthereumService;
            webBrowser1.ObjectForScripting = browserScriptInterface;

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
                    syncStatus = Connection.EthereumService.GetSyncing();
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
                var block = Connection.EthereumService.GetBlockByHash(value, true);
                webBrowser1.DocumentText = HtmlService.BlockHtml(block);
                return;
            }
            catch (Exception exception)
            {
               
            }

            try
            {
                var tx = Connection.EthereumService.GetTransactionByHash(value);
                webBrowser1.DocumentText = HtmlService.TransactionHtml(tx);
            }
            catch (Exception)
            {

            }
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            var frmAccountPassword = new FrmAccountPassword(Connection);
            frmAccountPassword.ShowDialog();

        }
    }
}
