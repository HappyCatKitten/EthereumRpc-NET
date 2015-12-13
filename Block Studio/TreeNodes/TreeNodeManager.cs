using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.Project;

namespace BlockStudio.TreeNodes
{
    public class TreeNodeManager
    {
        public static TreeView TreeView { get; set; }

        public static ConnectionNode GetConnectionNode()
        {
            var connnectionNode = TreeView.Nodes.Cast<BaseTreeNode>().FirstOrDefault(x => x.NodeType == NodeType.Connection);
            return (ConnectionNode)connnectionNode;
        }

        public static void UpdateAccountNode(Account account)
        {
            var list = TreeView.Nodes.Find(NodeType.Account.ToString(), true);
            var accountNodes = list.Cast<AccountNode>().Where(x => x.Account.Address == account.Address).ToList();
            foreach (var accountNode in accountNodes)
            {
                accountNode.ImageIndex = account.ImageIconIndex;
                accountNode.SelectedImageIndex = account.ImageIconIndex;
            }
        }

        public static void UpsertSolcFiles()
        {
            var solcProjectFiles = BlockStudioProjectService.BlockStudioProject.SolcProjectFiles;
            var solcParentNode = TreeView.Nodes.Find(NodeType.SolcParent.ToString(), true).FirstOrDefault();
            solcParentNode.Nodes.Clear();


            foreach (var solcProjectFile in solcProjectFiles)
            {
                var solTreeNode = new SolcTreeNode();
                solTreeNode.Text = solcProjectFile.FileName;
                solcParentNode.Nodes.Add(solTreeNode);
            }

            solcParentNode.ExpandAll();
        }


        public static void UpdateConnectionNodes()
        {
            //var connectionNodes = GetConnectionNodes();
            //foreach (var treeNode in connectionNodes)
            //{
            //   treeNode.Connection = BlockStudioProjectService.BlockStudioProject.SavedConnections.FirstOrDefault(x => x.Uid == treeNode.Connection.Uid);
            //   treeNode.Text = treeNode.Connection.Name; 
            //}
        }

        public static void ExpandConnectionProperties(ConnectionNode connectionNode)
        {
            var accounts = BlockStudioProjectService.BlockStudioProject.Accounts;
            connectionNode.Nodes[0].Nodes.Clear();

            foreach (var account in accounts)
            {
                var accountNode = new AccountNode();

                accountNode.Text = account.Label;

                if (account.LockState == LockedState.Locked)
                {
                    accountNode.ImageIndex = 3;
                    accountNode.SelectedImageIndex = 3;
                }
                else if (account.LockState == LockedState.Unlocked)
                {
                    accountNode.ImageIndex = 4;
                    accountNode.SelectedImageIndex = 4;
                }
                else if (account.LockState == LockedState.WrongPassword)
                {
                    accountNode.ImageIndex = 6;
                    accountNode.SelectedImageIndex = 6;
                }

                accountNode.Account = account;
                accountNode.Name = NodeType.Account.ToString();

                var addressNode = new AddressNode(account.Address);
                var balanceNode = new BalanceNode(string.Format("Balance: {0} Eth", account.BalanceEther));
                accountNode.Nodes.Add(addressNode);
                accountNode.Nodes.Add(balanceNode);

                connectionNode.Nodes[0].Nodes.Add(accountNode);
            }
        }


        public static void RefreshProject()
        {
            TreeView.Nodes.Clear();
            RebuildTree();
        }

        public static void RebuildTree()
        {
            var connectionNode = new ConnectionNode();
            connectionNode.Text = BlockStudioProjectService.BlockStudioProject.Name;
            connectionNode.Name = NodeType.Connection.ToString();

            connectionNode.Nodes.Add(new AccountParentNode() { Text = "Accounts" });
            var solidifyNode = new SolcParentTreeNode() {Text = "Solidify compiler files"};
            solidifyNode.Name = NodeType.SolcParent.ToString();
            connectionNode.Nodes.Add(solidifyNode);

            TreeView.Nodes.Insert(TreeView.Nodes.Count, connectionNode);
            TreeView.SelectedNode = connectionNode;
        }

    }
}
