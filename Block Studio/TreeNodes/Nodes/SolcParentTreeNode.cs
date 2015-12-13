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
    public class SolcParentTreeNode : BaseTreeNode
    {
        public SolcParentTreeNode()
        {
            this.NodeType = NodeType.Solc;
            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
        }
    }
}
