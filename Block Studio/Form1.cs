using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.Dialogs;
using BlockStudio.Persistant;
using BlockStudio.Tabs;
using BlockStudio.TreeNodes;
using Ethereum.Wallet.Persistant;

namespace BlockStudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var newConnectionNode = new NewConnectionNode();
            tvConnections.Nodes.Add(newConnectionNode);
            TreeNodeManager.TreeView = tvConnections;
            TabManager.TabControl = tabControl1;

            PersistantState.LoadStates();
            LoadTreeNodeConnections();

            tvConnections.NodeMouseClick += TvConnections_MouseUp;
        }

        private void LoadTreeNodeConnections()
        {
            foreach (var savedConnection in PersistantState.SavedConnections)
            {
                TreeNodeManager.AddConnectionNodeIfNew(savedConnection);
            }
        }

        private void TvConnections_MouseUp(object sender, MouseEventArgs e)
        {
            var p = new Point(e.X, e.Y);
            var baseTreeNode = (BaseTreeNode)tvConnections.GetNodeAt(p);

            // check if the right mouse button was pressed
            if (e.Button == MouseButtons.Left)
            {
                TvConnectionsLeftClick(baseTreeNode);
            }
            else if (e.Button == MouseButtons.Right)
            {
                tvConnections.SelectedNode = baseTreeNode;
                TvConnectionsRightClick(baseTreeNode);
            }
        }

        private void TvConnectionsRightClick(BaseTreeNode baseTreeNode)
        {
            if (baseTreeNode.NodeType == NodeType.NewConnection)
            {

            }
            else if (baseTreeNode.NodeType == NodeType.Connection)
            {
                tvConnections.ContextMenuStrip = ConnectionNodeContextMenu;
            }

        }

        private void TvConnectionsLeftClick(BaseTreeNode baseTreeNode)
        {
            //var thisNode = (BaseTreeNode) e.Node;
            if (baseTreeNode.NodeType==NodeType.NewConnection)
            {
                var frmNewConnection = new FrmNewConnection();
                frmNewConnection.ShowDialog();

                LoadTreeNodeConnections();
            }
            else if (baseTreeNode.NodeType == NodeType.Connection)
            {
                var connectionNode = (ConnectionNode)baseTreeNode;
                OpenOrSetTab(connectionNode.SavedConnection);
            }
        }

        private void OpenOrSetTab(SavedConnection savedConnection)
        {
            TabManager.AddConnectionTabIfNew(savedConnection);
            TabManager.SetSelectedTab(savedConnection);
        }

        private void renameConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this connection", "Block Studio",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var selectedNode = (ConnectionNode)tvConnections.SelectedNode;
                var savedConnection = selectedNode.SavedConnection;
                PersistantState.RemoveSavedConnection(savedConnection);
                tvConnections.SelectedNode = null;
                tvConnections.Nodes.Remove(selectedNode);
            }

        }
    }
}
