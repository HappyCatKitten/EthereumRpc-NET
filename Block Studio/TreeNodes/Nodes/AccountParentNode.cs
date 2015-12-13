using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockStudio.TreeNodes
{
    public class AccountParentNode : BaseTreeNode
    {
        public AccountParentNode()
        {
            this.NodeType = NodeType.AccountParent;
            this.ImageIndex = 2;
            this.SelectedImageIndex = 2;
        }
    }
}
