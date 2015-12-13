using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.Project;

namespace BlockStudio.TreeNodes
{
    public class ConnectionNode : BaseTreeNode
    {
        public bool HasConnected { get; set; }

        public ConnectionNode()
        {
            this.NodeType = NodeType.Connection;
            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
        }
    }
}
