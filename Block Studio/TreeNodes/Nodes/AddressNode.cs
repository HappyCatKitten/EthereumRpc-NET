using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockStudio.Project;

namespace BlockStudio.TreeNodes
{
    public class AddressNode : BaseTreeNode
    {

        public AddressNode(string text)
        {
            this.Text = text;
            this.NodeType = NodeType.Address;
            this.ImageIndex = 2;
            this.SelectedImageIndex = 2;
        }

        public AddressNode()
        {

        }
    }
}
