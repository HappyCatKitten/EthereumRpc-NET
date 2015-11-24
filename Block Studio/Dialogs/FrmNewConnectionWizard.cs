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
using BlockStudio.Ethereum;
using BlockStudio.Persistant;
using EthereumRpc;

namespace BlockStudio.Dialogs
{
    public partial class FrmNewConnectionWizard: Form
    {
        public FrmNewConnectionWizard()
        {
            InitializeComponent();

            

            var connections = new List<Connection>()
            {
                new Connection() {ConnectionType = ConnectionType.Attach,Name="Attach to Ethereum Instance",Port="8545",PrivateChain = false,Uid = Guid.NewGuid().ToString()},
                new Connection() {ConnectionType = ConnectionType.Instance,Name="New Private Ethereum Instance",Port="8545",PrivateChain = true,Uid = Guid.NewGuid().ToString()},
                new Connection() {ConnectionType = ConnectionType.Instance,Name="Frontier Ethereum Instance",Port="8545",PrivateChain = false,Uid = Guid.NewGuid().ToString()}
            };


            foreach (var connection in connections)
            {
                var listviewItem = new ListViewItem(connection.Name, 0);
                listviewItem.Tag = connection;
                lvCreate.Items.Add(listviewItem);
            }
            

        }

        private void lvCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lvCreate.SelectedItems.Count > 0)
            {
                var savedConnection = (Connection)lvCreate.SelectedItems[0].Tag;
                pgOptions.SelectedObject = savedConnection;
                txtProjectName.Text = string.Format("{0} {1}", savedConnection.Name, PersistantState.SavedConnections.Count + 1);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            TestConnection();
            this.Enabled = true;
        }

        

        private void TestConnection()
        {
            var savedConnection = (Connection)pgOptions.SelectedObject;

            if (savedConnection.ConnectionType==ConnectionType.Instance)
            {
                GethService.RunGethInstance(savedConnection);
            }
            else
            {
                var url = savedConnection.Url;
                var port = savedConnection.Port;
                var ethereumService = new EthereumService(url, port);

                try
                {
                    var version = ethereumService.GetWeb3ClientVersion();
                    var result = MessageBoxEx.Show(this, "Connection Successful", "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception)
                {
                    var result = MessageBoxEx.Show(this, string.Format("Could not connect, is Ethereum running on port {0}?",savedConnection.Port), "Block Studio", MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error);

                    if (result == DialogResult.Retry)
                    {
                        TestConnection();
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var savedConnection = (Connection)pgOptions.SelectedObject;
            savedConnection.Name = txtProjectName.Text;
            PersistantState.SavedConnection(savedConnection);
            this.Close();
        }
    
    }
}
