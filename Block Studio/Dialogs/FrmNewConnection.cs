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
    public partial class FrmNewConnection : Form
    {
        public Connection Connection { get; set; }
        public FrmNewConnection(Connection connection = null)
        {
            InitializeComponent();

            if (connection == null)
            {
                Connection = new Connection();
                Connection.Uid = Guid.NewGuid().ToString();
                txtName.Text = string.Format("Ethereum Connection {0}", PersistantState.SavedConnections.Count + 1);
                txtPrivateChainPath.Text = string.Format("{0}{1}", GethService.ExecutingFolder, txtName.Text);
                rbAttach.PerformClick();
            }
            else
            {
                Connection = connection;

                txtAttachPort.Text = Connection.Port;
                txtAttachUrl.Text = Connection.Url;
                txtName.Text = Connection.Name;
                txtPrivateChainPath.Text = connection.PrivateChainPath;
                chbPrivateChain.Checked = connection.PrivateChain;

                if (connection.ConnectionType == ConnectionType.Attach)
                {
                    rbAttach.PerformClick();
                }
                if (connection.ConnectionType == ConnectionType.Instance)
                {
                    rbCreateInstance.PerformClick();
                }
            }  
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void TestConnection()
        {
            var url = txtAttachUrl.Text;
            var port = txtAttachPort.Text;
            var ethereumService = new EthereumService(url, port);

            try
            {
                var version = ethereumService.GetWeb3ClientVersion();
                var result = MessageBoxEx.Show(this,"Connection Successful", "Block Studio", MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {
                var result = MessageBoxEx.Show(this,"Could not connect", "Block Studio", MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    TestConnection();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Connection.Name = txtName.Text;

            if (rbAttach.Checked)
            {
                Connection.Port = txtAttachPort.Text;
                Connection.Url = txtAttachUrl.Text;
                Connection.ConnectionType = ConnectionType.Attach;
            }
            else if (rbCreateInstance.Checked)
            {
                Connection.Port = txtNewInstancePort.Text;
                Connection.PrivateChain = chbPrivateChain.Checked;
                Connection.PrivateChainPath = txtPrivateChainPath.Text;
                Connection.ConnectionType = ConnectionType.Instance;
            }
            
            PersistantState.SavedConnection(Connection);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbAttach_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton) sender;

            if (rb.Checked)
            {
                rbCreateInstance.Checked = false;
                rbAttach.Checked = true;
                txtAttachPort.Enabled = true;
                txtAttachUrl.Enabled = true;

                txtNewInstancePort.Enabled = false;
            }
        }


        private void rbCreateInstance_CheckedChanged(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;

            if (rb.Checked)
            {
                rbCreateInstance.Checked = true;
                txtAttachPort.Enabled = false;
                rbAttach.Checked = false;
                txtAttachUrl.Enabled = false;

                txtNewInstancePort.Enabled = true;
            }
        }

        private void chbPrivateChain_CheckedChanged(object sender, EventArgs e)
        {
            txtPrivateChainPath.Enabled = chbPrivateChain.Checked;
        }

        private void btnPrivateChainPathGet_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = string.Format("{0}{1}", GethService.ExecutingFolder, txtName);
            dialog.Description = @"Select Folder for private blockchain files";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtPrivateChainPath.Text = dialog.SelectedPath;
            }
        }
    }
}
