using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ethereum.Wallet.Persistant;
using EthereumRpc;

namespace Block_Studio.CustomControls
{
    public partial class ConnectionPanel : UserControl
    {
        public SavedConnection SavedConnection{ get; set; }
        public EthereumService EthereumService { get; set; }

        public ConnectionPanel(SavedConnection savedConnection)
        {
            SavedConnection = savedConnection;
            EthereumService = new EthereumService(SavedConnection.Url,SavedConnection.Url);

            InitializeComponent();
        }
    }
}
