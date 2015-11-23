using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Block_Studio.TreeNodes
{
    public class NewConnectionNode : BaseTreeNode
    {
        public NewConnectionNode()
        {
            NodeType = NodeType.NewConnection;
            this.Text = "New Connection";
            this.ImageIndex = 0;
            this.SelectedImageIndex = 0;
        }
    }
}
