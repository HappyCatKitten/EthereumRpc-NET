using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.CustomControls;
using BlockStudio.Dialogs;
using BlockStudio.Ethereum;
using BlockStudio.Persistant;
using BlockStudio.Tabs;
using BlockStudio.TreeNodes;

namespace BlockStudio
{
    public partial class Form1 : Form
    {
        public BaseTreeNode SelectedNode{ get; set; }
        public Form1()
        {
            InitializeComponent();

            var newConnectionNode = new NewConnectionNode();
            tvConnections.Nodes.Add(newConnectionNode);
            TreeNodeManager.TreeView = tvConnections;
            TabManager.TabControl = tabControl1;

            PersistantState.LoadStates();
            LoadTreeNodeConnections();

            tvConnections.NodeMouseClick += TvConnections_Click;
            tvConnections.NodeMouseDoubleClick += TvConnections_NodeMouseDoubleClick;
            tvConnections.BeforeExpand += TvConnections_BeforeExpand;
        }

        private void TvConnections_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var baseTreeNode = (BaseTreeNode) e.Node;

            if (baseTreeNode.NodeType == NodeType.Connection)
            {
                var connectionNode = (ConnectionNode) baseTreeNode;
                if (!connectionNode.HasLoaded)
                {
                    AttemptConnection(connectionNode);
                    connectionNode.HasLoaded = true;
                } 
            }
        }

        private void AttemptConnection(ConnectionNode connectionNode)
        {
            // attempt connection
            var connectionStatus = connectionNode.Connection.GetConnectionProperties();

            if (connectionStatus == ConnectionStatus.CouldNotConnect)
            {
                MessageBoxEx.Show(this, "Could not connect to Ethereum", "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (connectionStatus == ConnectionStatus.ConnectedButPersonalNotSuppored)
            {
                MessageBoxEx.Show(this, "Connected But Personal Not Suppored", "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                TreeNodeManager.ExpandConnectionProperties(connectionNode);
            }
        }

        private void TvConnections_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var p = new Point(e.X, e.Y);
            var baseTreeNode = (BaseTreeNode)tvConnections.GetNodeAt(p);
            TvConnectionsLeftClick(baseTreeNode);

        }

        private void LoadTreeNodeConnections()
        {
            foreach (var savedConnection in PersistantState.SavedConnections)
            {
                TreeNodeManager.AddConnectionNodeIfNew(savedConnection);
            }
        }

        //private void UpdateNode(Connection Connection)
        //{
        //    foreach (var Connection in Persistance.SavedConnections)
        //    {
        //        TreeNodeManager.AddConnectionNodeIfNew(Connection);
        //    }
        //}

        private void TvConnections_Click(object sender, MouseEventArgs e)
        {
            var p = new Point(e.X, e.Y);
            var baseTreeNode = (BaseTreeNode)tvConnections.GetNodeAt(p);

            // check if the right mouse button was pressed
            if (e.Button == MouseButtons.Left)
            {
                //TvConnectionsLeftClick(baseTreeNode);
            }
            else if (e.Button == MouseButtons.Right)
            {
                tvConnections.SelectedNode = baseTreeNode;
                TvConnectionsRightClick(baseTreeNode);
            }
        }

        private void TvConnectionsRightClick(BaseTreeNode treeNode)
        {
            SelectedNode = treeNode;

            if (treeNode.NodeType == NodeType.NewConnection)
            {

            }
            else if (treeNode.NodeType == NodeType.Connection)
            {
                var connectionNode = (ConnectionNode)(treeNode);

                if (connectionNode.Connection.ConnectionType == ConnectionType.Instance)
                {
                    ConnectionNodeContextMenu.Items[3].Enabled = true;
                }
                else
                {

                    ConnectionNodeContextMenu.Items[3].Enabled = false;
                }

                tvConnections.ContextMenuStrip = ConnectionNodeContextMenu;
            }
            else if (treeNode.NodeType == NodeType.AccountParent)
            {
                tvConnections.ContextMenuStrip = AccountParentContextMenuStrip;
            }
            else if (treeNode.NodeType == NodeType.Account)
            {
                var accountNode = (AccountNode) treeNode;
                if (accountNode.Account.Locked)
                {
                    AccountContextMenuStrip.Items[0].Enabled = true;
                    AccountContextMenuStrip.Items[1].Enabled = false;
                }
                else
                {
                    AccountContextMenuStrip.Items[0].Enabled = false;
                    AccountContextMenuStrip.Items[1].Enabled = true;
                }
                tvConnections.ContextMenuStrip = AccountContextMenuStrip;
            }

        }

        private void TvConnectionsLeftClick(BaseTreeNode baseTreeNode)
        {
            //var thisNode = (BaseTreeNode) e.Node;
            if (baseTreeNode.NodeType==NodeType.NewConnection)
            {
                //var frmNewConnection = new FrmNewConnection();
                // frmNewConnection.ShowDialog();

                var frmNewConnection = new FrmNewConnectionWizard();
                 frmNewConnection.ShowDialog();

                LoadTreeNodeConnections();
            }
            else if (baseTreeNode.NodeType == NodeType.Connection)
            {
                var connectionNode = (ConnectionNode)baseTreeNode;

                if (!connectionNode.HasLoaded)
                {
                    AttemptConnection(connectionNode);
                    connectionNode.HasLoaded = true;
                }

                OpenOrSetTab(connectionNode.Connection);
            }
        }

        private void OpenOrSetTab(Connection connection)
        {
            TabManager.AddConnectionTabIfNew(connection);
            TabManager.SetSelectedTab(connection);
        }

        private void renameConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBoxEx.Show(this,"Are you sure you want to delete this connection", "Block Studio",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var selectedNode = (ConnectionNode)tvConnections.SelectedNode;
                var savedConnection = selectedNode.Connection;
                PersistantState.RemoveSavedConnection(savedConnection);
                tvConnections.SelectedNode = null;
                tvConnections.Nodes.Remove(selectedNode);
            }

        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = (ConnectionNode)tvConnections.SelectedNode;
            var savedConnection = selectedNode.Connection;

            var frmNewConnection = new FrmNewConnection(savedConnection);
            frmNewConnection.ShowDialog();

            TreeNodeManager.UpdateConnectionNodes();
        }

        private void LaunchInstanceMenuItem_Click(object sender, EventArgs e)
        {
            var selectedNode = (ConnectionNode)tvConnections.SelectedNode;
            var savedConnection = selectedNode.Connection;

            GethService.RunGethInstance(savedConnection);
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionNode = (ConnectionNode)SelectedNode.Parent;
            var frm = new FrmAccountPassword(connectionNode.Connection);
            frm.ShowDialog(this);
            AttemptConnection(connectionNode);
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionNode = (ConnectionNode)(SelectedNode);
            AttemptConnection(connectionNode);
        }

        private void unlockAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var accountNode = (AccountNode)(SelectedNode);
            var connectionNode = (ConnectionNode)(SelectedNode.Parent.Parent);
            var frm = new FrmAccountPassword(connectionNode.Connection, accountNode.Account.AccountId);
            frm.ShowDialog(this);
            AttemptConnection(connectionNode);
        }
    }
}
