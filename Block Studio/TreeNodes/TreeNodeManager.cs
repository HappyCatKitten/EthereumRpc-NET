using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ethereum.Wallet.Persistant;

namespace Block_Studio.TreeNodes
{
    public class TreeNodeManager
    {
        public static TreeView TreeView { get; set; }
        public static List<ConnectionNode> GetConnectionNodes()
        {
            var list = TreeView.Nodes.Cast<BaseTreeNode>().Where(x => x.NodeType == NodeType.Connection).ToList();
            return list.Cast<ConnectionNode>().ToList();
        }

        public static ConnectionNode GetConnectionNodeBySavedConnection(SavedConnection savedConnection)
        {
            var list = TreeView.Nodes.Cast<BaseTreeNode>().Where(x => x.NodeType == NodeType.Connection).ToList();
            var connectionNodes = list.Cast<ConnectionNode>().ToList();
            return connectionNodes.FirstOrDefault(x => x.SavedConnection.Uid == savedConnection.Uid);
        }

        public static void AddConnectionNodeIfNew(SavedConnection savedConnection)
        {
            var currentConnections = GetConnectionNodes();

            if (currentConnections.All(x => x.SavedConnection.Uid != savedConnection.Uid))
            {
                var connectionNode = new ConnectionNode();
                connectionNode.Text = savedConnection.Name;
                connectionNode.SavedConnection = savedConnection;
                TreeView.Nodes.Insert(TreeView.Nodes.Count, connectionNode);
                TreeView.SelectedNode = connectionNode;
            }
        }

        public static void SetConnectionNodeAsSelected(SavedConnection savedConnection)
        {
            var node = GetConnectionNodeBySavedConnection(savedConnection);
            TreeView.SelectedNode = node;
        }

    }
}
