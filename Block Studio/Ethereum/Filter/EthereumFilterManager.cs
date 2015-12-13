using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.Project;
using EthereumRpc.RpcObjects;

namespace BlockStudio.Ethereum.Filter
{
    public class EthereumFilterManager
    {
        public List<string> FilterIds { get; set; }
        private BackgroundWorker bgWorker;
        private string _txHashFilterId;
        private string _newTxHash;
        private bool _started;
        private readonly TextBox _consoleTextBox;


        public EthereumFilterManager(TextBox consoleTextBox)
        {
            _consoleTextBox = consoleTextBox;
            _txHashFilterId = BlockStudioProjectService.BlockStudioProject.Connection.EthereumService.NewBlockFilter();
        }

        public void AddBlockPendingFilter(string txHash)
        {
            _newTxHash = txHash;
        }

        public void Start()
        {
            if (!_started)
            {
                bgWorker = new BackgroundWorker();
                bgWorker.DoWork += WorkerAttemptConnection;
                bgWorker.RunWorkerAsync();
                _started = true;
            }
        }

        /// <summary>
        /// Queries the filter to find the new transaction
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WorkerAttemptConnection(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var blockTxHashes = BlockStudioProjectService.BlockStudioProject.Connection.EthereumService.GetBlockFilterChanges(_txHashFilterId);
                if (blockTxHashes.Any())
                {
                    // a new block has arrived
                    foreach (var blockTxHash in blockTxHashes)
                    {
                        var block = BlockStudioProjectService.BlockStudioProject.Connection.EthereumService.GetBlockByHash(blockTxHash,true);

                        var tx = block.TransactionsFull.FirstOrDefault(x => x.Hash == _newTxHash);

                        // the tx is now on the blockchain
                        if (tx != null)
                        {
                            BlockStudioProjectService.TransactionReceipt = BlockStudioProjectService.BlockStudioProject.Connection.EthereumService.GetTransactionReceipt(tx.Hash);
                            _consoleTextBox.WriteConsonsoleMessage("Contract mined!: {0}", BlockStudioProjectService.TransactionReceipt.ContractAddress);
                            
                        }
                    }
                }

                Thread.Sleep(500);
            }
        }
    }
}
