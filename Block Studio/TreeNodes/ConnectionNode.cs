﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.Persistant;

namespace BlockStudio.TreeNodes
{
    public class ConnectionNode : BaseTreeNode
    {
        public Connection Connection { get; set; }
        public bool HasLoaded { get; set; }

        public ConnectionNode()
        {
            this.NodeType = NodeType.Connection;
            this.ImageIndex = 1;
            this.SelectedImageIndex = 1;
            
        }
    }
}