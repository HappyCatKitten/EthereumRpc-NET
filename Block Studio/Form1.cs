using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Block_Studio.Dialogs;
using Block_Studio.Persistant;
using Block_Studio.Tabs;
using Block_Studio.TreeNodes;
using Ethereum.Wallet.Persistant;

namespace Block_Studio
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

                // iterate through all the tab pages
                //for (int i = 0; i < tabControl1.TabCount; i++)
                //{
                //    // get their rectangle area and check if it contains the mouse cursor
                //    Rectangle r = tabControl1.GetTabRect(i);
                //    if (r.Contains(e.Location))
                //    {
                //        // show the context menu here
                //        System.Diagnostics.Debug.WriteLine("TabPressed: " + i);
                //    }
                //}
            }
        }

        private void TvConnectionsRightClick(BaseTreeNode baseTreeNode)
        {
            var contextMenuStrip =  new ContextMenuStrip();
            contextMenuStrip.Items.Add("fuck you");
            tvConnections.ContextMenuStrip = contextMenuStrip;

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
    }
}
