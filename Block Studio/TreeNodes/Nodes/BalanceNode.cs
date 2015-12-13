using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockStudio.Project;

namespace BlockStudio.TreeNodes
{
    public class BalanceNode : BaseTreeNode
    {
        public BalanceNode(string text)
        {
            this.Text = text;
            this.NodeType = NodeType.Balance;
            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
        }

        public BalanceNode()
        {

        }
    }
}
