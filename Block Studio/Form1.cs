using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.CustomControls;
using BlockStudio.Dialogs;
using BlockStudio.Ethereum;
using BlockStudio.HtmlGenerator;
using BlockStudio.Project;
using BlockStudio.Settings;
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
            TreeNodeManager.TreeView = tvConnections;

            BlockStudioProjectService.BlockStudioSettings = BlockStudioSettings.Load();

            if (BlockStudioProjectService.BlockStudioSettings.RecentProjects.Any())
            {
                var lastProject = BlockStudioProjectService.BlockStudioSettings.RecentProjects.LastOrDefault();
                BlockStudioProjectService.BlockStudioProject = BlockStudioProject.LoadFromPath(lastProject);
                LoadProject();

            }
            else
            {
                //NewProjectDialog();
            }

            tvConnections.NodeMouseClick += TvConnections_Click;
            tvConnections.NodeMouseDoubleClick += TvConnections_NodeMouseDoubleClick;
            tvConnections.BeforeExpand += TvConnections_BeforeExpand;
            tvConnections.KeyDown += TvConnections_KeyDown;

            
            HtmlTabManager.HtmlEditorTextBox = txtHtmlEditor;
        }

        private void LoadProject()
        {
            if (BlockStudioProjectService.BlockStudioProject != null)
            {
                TreeNodeManager.RefreshProject();

                var runningPort = BlockStudioProjectService.BlockStudioProject.Connection.RpcPort;

                var gethInstanceState = GethService.GetPortAndInstanceUse(runningPort);
                if (gethInstanceState == GethInstanceState.NoInstanceRunning)
                {
                    // run geth
                    //GethService.RunGethInstance(BlockStudioProjectService.BlockStudioProject.Connection);
                    //Thread.Sleep(1000);
                    //AttemptConnection(TreeNodeManager.GetConnectionNode());
                    //connectionPanel1.BindControls();
                }

                tabControl1.Visible = true;
            }
        }

        private void TvConnections_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                //DeleteConnection();
            }
        }


        private void TvConnections_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (BlockStudioProjectService.BlockStudioProject == null)
            {
                return;
            }

            var baseTreeNode = (BaseTreeNode) e.Node;

            if (baseTreeNode.NodeType == NodeType.Connection)
            {
                var connectionNode = (ConnectionNode) baseTreeNode;
                if (!connectionNode.HasConnected)
                {
                    AttemptConnection(connectionNode);
                } 
            }
        }

        private void AttemptConnection(ConnectionNode connectionNode)
        {
            connectionNode.ImageIndex = 5;
            var rememberText = connectionNode.Text;
            connectionNode.Text = connectionNode.Text + (connectionNode.HasConnected ? " (Refreshing...)" : " (Loading...)");
            connectionNode.ForeColor = SystemColors.GrayText;
            tvConnections.SelectedNode = null;

            var bgWorker = new BackgroundWorker();
            bgWorker.DoWork += WorkerAttemptConnection;
            bgWorker.RunWorkerAsync(new { connectionNode ,rememberText});

            
        }

        private void WorkerAttemptConnection(object sender, DoWorkEventArgs e)
        {
            var values = (dynamic) e.Argument;
            var connectionNode = (ConnectionNode)values.connectionNode;
            var rememberText = values.rememberText;
            var connectionStatus = BlockStudioProjectService.BlockStudioProject.Connection.GetConnectionProperties();

            if (connectionStatus == ConnectionStatus.CouldNotConnect)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    
                    var result = MessageBoxEx.Show(this, string.Format("Could not connect, is Ethereum running on port {0}?", BlockStudioProjectService.BlockStudioProject.Connection.RpcPort), "Block Studio", MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error);

                    if (result == DialogResult.Retry)
                    {
                        AttemptConnection(connectionNode);
                    }
                });
            }
            else if (connectionStatus == ConnectionStatus.ConnectedButPersonalNotSuppored)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    MessageBoxEx.Show(this, string.Format(@"Connected but account creation not supported.{0}{0}Run geth with --rpcapi ""eth,web3,personal"" parameter", Environment.NewLine), "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
            }
            else
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    TreeNodeManager.ExpandConnectionProperties(connectionNode);

                    if (!connectionNode.HasConnected)
                    {
                        connectionNode.HasConnected = true;
                        connectionPanel1.BindControls();
                    }
                });

                
            }

            BeginInvoke((MethodInvoker)delegate
            {
                connectionNode.Text = rememberText;
                connectionNode.ForeColor = Color.Black;
                connectionNode.ImageIndex = 1;
            });
        }

        private void TvConnections_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (BlockStudioProjectService.BlockStudioProject == null)
            {
                return;
            }

            var p = new Point(e.X, e.Y);
            var baseTreeNode = (BaseTreeNode)tvConnections.GetNodeAt(p);
            TvConnectionsLeftClick(baseTreeNode);
        }


        private void TvConnections_Click(object sender, MouseEventArgs e)
        {
            if (BlockStudioProjectService.BlockStudioProject == null)
            {
                return;
            }

            var p = new Point(e.X, e.Y);
            var selectedNode = tvConnections.GetNodeAt(p);

            if (selectedNode == null)
                return;

            var baseTreeNode = (BaseTreeNode) selectedNode;

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
            tvConnections.ContextMenuStrip = null;

            SelectedNode = treeNode;

            if (treeNode.NodeType == NodeType.NewConnection)
            {

            }
            else if (treeNode.NodeType == NodeType.Connection)
            {
                var connectionNode = (ConnectionNode)(treeNode);

                if (BlockStudioProjectService.BlockStudioProject.Connection.ConnectionType == ConnectionType.Instance)
                {
                    ConnectionNodeContextMenu.Items[0].Text = connectionNode.HasConnected ? "&Refresh" : "&Connect";
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
                var accountNode = (AccountNode)treeNode;
                if (accountNode.Account.LockState == LockedState.Unlocked)
                {
                    AccountContextMenuStrip.Items[0].Enabled = false;
                    AccountContextMenuStrip.Items[1].Enabled = true;
                }
                else
                {
                    AccountContextMenuStrip.Items[0].Enabled = true;
                    AccountContextMenuStrip.Items[1].Enabled = false;
                }

                tvConnections.ContextMenuStrip = AccountContextMenuStrip;
            }
            else if (treeNode.NodeType == NodeType.Address)
            {
                tvConnections.ContextMenuStrip = addressMenuStrip;
            }

        }

        private void TvConnectionsLeftClick(BaseTreeNode baseTreeNode)
        {
            if (baseTreeNode.NodeType == NodeType.Connection)
            {
                var connectionNode = (ConnectionNode)baseTreeNode;

                if (!connectionNode.HasConnected)
                {
                    AttemptConnection(connectionNode);
                    
                }
            }
        }

 

        private void renameConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DeleteConnection();

        }

        //private void DeleteConnection()
        //{
        //    var result = MessageBoxEx.Show(this, "Are you sure you want to delete this connection", "Block Studio", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

        //    if (result == DialogResult.Yes)
        //    {
        //        var selectedNode = (ConnectionNode)tvConnections.SelectedNode;
        //        var savedConnection = selectedNode.Connection;
        //        BlockStudioProjectService.RemoveSavedConnection(savedConnection);
        //        tvConnections.SelectedNode = null;
        //        tvConnections.Nodes.Remove(selectedNode);
        //    }
        //}


        private void LaunchInstanceMenuItem_Click(object sender, EventArgs e)
        {
            var getInstanceState = GethService.GetPortAndInstanceUse(BlockStudioProjectService.BlockStudioProject.Connection.RpcPort);
            if (getInstanceState == GethInstanceState.InstanceRunning)
            {
                MessageBoxEx.Show(this, string.Format("RpcPort {0} currently in use", BlockStudioProjectService.BlockStudioProject.Connection.RpcPort), "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                GethService.RunGethInstance(BlockStudioProjectService.BlockStudioProject.Connection);
            }
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var connectionNode = (ConnectionNode)SelectedNode.Parent;
            var frm = new FrmAccountProperties(BlockStudioProjectService.BlockStudioProject.Connection, 0);
            frm.ShowDialog(this);

            BlockStudioProjectService.BlockStudioSettings.SetLastProjectLocation(BlockStudioProjectService.BlockStudioProject.ProjectFileSavePath);

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
            var frm = new FrmAccountProperties(BlockStudioProjectService.BlockStudioProject.Connection, 1,accountNode.Account);
            frm.ShowDialog(this);
            AttemptConnection(connectionNode);
        }

        private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProjectDialog();
        }

        private void NewProjectDialog()
        {
            var frmNewConnection = new FrmNewProject();
            frmNewConnection.ShowDialog();

            BlockStudioProjectService.BlockStudioSettings.SetLastProjectLocation(BlockStudioProjectService.BlockStudioProject.ProjectFileSavePath);

            LoadProject();
        }

        private void renameAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var accountNode = (AccountNode)(SelectedNode);
            var connectionNode = (ConnectionNode)accountNode.Parent.Parent;
            var frm = new FrmAccountProperties(BlockStudioProjectService.BlockStudioProject.Connection, 0, accountNode.Account);
            frm.ShowDialog(this);
            AttemptConnection(connectionNode);
        }

        private void copyAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var addressNode = (AddressNode)(SelectedNode);
            Clipboard.SetText(addressNode.Text);
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new ConnectionProperties();
            frm.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new FrmOptions();
            frm.ShowDialog();
        }


    }
}
