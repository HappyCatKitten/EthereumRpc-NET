using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockStudio.TreeNodes
{
    public class NewConnectionNode : BaseTreeNode
    {
        public NewConnectionNode()
        {
            NodeType = NodeType.NewConnection;
            Text = "Add connection";
            ImageIndex = 0;
            SelectedImageIndex = 0;
        }
    }
}
