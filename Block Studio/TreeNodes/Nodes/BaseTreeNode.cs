using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockStudio.TreeNodes
{
    public class BaseTreeNode : TreeNode
    {
        public NodeType NodeType { get; set; }

        public BaseTreeNode()
        {

        }
    }
}
