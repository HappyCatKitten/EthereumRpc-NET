using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Block_Studio.CustomControls;
using Ethereum.Wallet.Persistant;

namespace Block_Studio.Tabs
{
    public class Tab : TabPage
    {
        public SavedConnection SavedConnection { get; set; }
        public ConnectionPanel ConnectionPanel{ get; set; }

        public Tab(SavedConnection savedConnection)
        {
            SavedConnection = savedConnection;

            ConnectionPanel = new ConnectionPanel(savedConnection);
            ConnectionPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            ConnectionPanel.BorderStyle = BorderStyle.FixedSingle;
            ConnectionPanel.Width = this.Width;
            ConnectionPanel.Height = this.Height;
            
            this.Controls.Add(ConnectionPanel);
        }
    }
}
