using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Block_Studio.Persistant;
using Ethereum.Wallet.Persistant;
using EthereumRpc;

namespace Block_Studio.Dialogs
{
    public partial class FrmNewConnection : Form
    {
        public FrmNewConnection()
        {
            InitializeComponent();

            txtName.Text = string.Format("Ethereum Connection {0}", PersistantState.SavedConnections.Count + 1);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void TestConnection()
        {
            var url = txtUrl.Text;
            var port = txtPort.Text;
            var ethereumService = new EthereumService(url, port);

            try
            {
                var version = ethereumService.GetWeb3ClientVersion();
                var result = MessageBox.Show("Connection Successful", "Block Studio", MessageBoxButtons.OK,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
            }
            catch (Exception)
            {
                var result = MessageBox.Show("Could not connect", "Block Studio", MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.Retry)
                {
                    TestConnection();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var savedConnection = new SavedConnection();
            savedConnection.Port = txtPort.Text;
            savedConnection.Url = txtUrl.Text;
            savedConnection.Name = txtName.Text;
            savedConnection.Uid = Guid.NewGuid().ToString();
            PersistantState.AddSavedConnection(savedConnection);
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
