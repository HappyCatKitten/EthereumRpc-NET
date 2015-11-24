using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.Persistant;

namespace BlockStudio.TreeNodes
{
    public class TreeNodeManager
    {
        public static TreeView TreeView { get; set; }
        public static List<ConnectionNode> GetConnectionNodes()
        {
            var list = TreeView.Nodes.Cast<BaseTreeNode>().Where(x => x.NodeType == NodeType.Connection).ToList();
            return list.Cast<ConnectionNode>().ToList();
        }

        public static void UpdateConnectionNodes()
        {
            var connectionNodes = GetConnectionNodes();
            foreach (var treeNode in connectionNodes)
            {
               treeNode.Connection = PersistantState.SavedConnections.FirstOrDefault(x => x.Uid == treeNode.Connection.Uid);
               treeNode.Text = treeNode.Connection.Name; 
            }
        }

        public static void ExpandConnectionProperties(ConnectionNode connectionNode)
        {
            var accounts = connectionNode.Connection.Accounts;
            connectionNode.Nodes[0].Nodes.Clear();

            foreach (var account in accounts)
            {
                var accountNode = new AccountNode();
                accountNode.Text = account.AccountId;
                accountNode.ImageIndex = account.Locked ? 3 : 4;
                accountNode.SelectedImageIndex = account.Locked ? 3 : 4;
                accountNode.Account = account;
                connectionNode.Nodes[0].Nodes.Add(accountNode);
            }
        }

        

        public static ConnectionNode GetConnectionNodeBySavedConnection(Connection connection)
        {
            var list = TreeView.Nodes.Cast<BaseTreeNode>().Where(x => x.NodeType == NodeType.Connection).ToList();
            var connectionNodes = list.Cast<ConnectionNode>().ToList();
            return connectionNodes.FirstOrDefault(x => x.Connection.Uid == connection.Uid);
        }

        public static void AddConnectionNodeIfNew(Connection connection)
        {
            var currentConnections = GetConnectionNodes();

            if (currentConnections.All(x => x.Connection.Uid != connection.Uid))
            {
                var connectionNode = new ConnectionNode();
                connectionNode.Text = connection.Name;
                connectionNode.Connection = connection;

                connectionNode.Nodes.Add(new AccountParentNode() { Text = "Accounts" });

                TreeView.Nodes.Insert(TreeView.Nodes.Count, connectionNode);
                TreeView.SelectedNode = connectionNode;


            }
        }

        public static void SetConnectionNodeAsSelected(Connection connection)
        {
            var node = GetConnectionNodeBySavedConnection(connection);
            TreeView.SelectedNode = node;
        }

    }
}
