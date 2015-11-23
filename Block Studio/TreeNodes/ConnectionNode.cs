using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ethereum.Wallet.Persistant;

namespace Block_Studio.TreeNodes
{
    public class ConnectionNode : BaseTreeNode
    {
        public SavedConnection SavedConnection { get; set; }
        public ConnectionNode()
        {
            this.NodeType = NodeType.Connection;
            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
            
        }
    }
}
