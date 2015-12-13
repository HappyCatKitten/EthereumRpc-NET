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
using BlockStudio.Project;
using EthereumRpc;

namespace BlockStudio.Dialogs
{
    public partial class ConnectionProperties : Form
    {
        public ConnectionProperties()
        {
            InitializeComponent();

            pgOptions.SelectedObject = BlockStudioProjectService.BlockStudioProject.Connection;

            SetCommandLinePreview();

            pgOptions.PropertyValueChanged += PgOptions_PropertyValueChanged;
        }

        private void PgOptions_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            SetCommandLinePreview();
        }

        private void SetCommandLinePreview()
        {
            var command = GethService.GetCommandLineArgs(BlockStudioProjectService.BlockStudioProject.Connection);
            txtCommandLineArgs.Text = "geth " + command;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestConnection();
        }

        private void TestConnection()
        {
            var savedConnection = (Connection)pgOptions.SelectedObject;

            if (savedConnection.ConnectionType == ConnectionType.Instance)
            {
                var getInstanceState = GethService.GetPortAndInstanceUse(savedConnection.RpcPort);
                if (getInstanceState == GethInstanceState.InstanceRunning)
                {
                    MessageBoxEx.Show(this, string.Format("RpcPort {0} currently in use", savedConnection.RpcPort), "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    GethService.RunGethInstance(savedConnection,true);
                }

            }
            else
            {
                var url = savedConnection.Url;
                var port = savedConnection.RpcPort;
                var ethereumService = new EthereumService(url, port);

                try
                {
                    var version = ethereumService.GetWeb3ClientVersion();
                    var result = MessageBoxEx.Show(this, "_connection Successful", "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception)
                {
                    var result = MessageBoxEx.Show(this, string.Format("Could not connect, is Ethereum running on port {0}?", savedConnection.RpcPort), "Block Studio", MessageBoxButtons.RetryCancel,
                        MessageBoxIcon.Error);

                    if (result == DialogResult.Retry)
                    {
                        TestConnection();
                    }
                }
            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            BlockStudioProjectService.BlockStudioProject.Connection = BlockStudioProjectService.BlockStudioProject.Connection;
            BlockStudioProjectService.BlockStudioProject.SaveToDisk();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }






    }
}
