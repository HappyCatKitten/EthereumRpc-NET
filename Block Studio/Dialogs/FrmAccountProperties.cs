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
using BlockStudio.Project;
using EthereumRpc;

namespace BlockStudio.Dialogs
{
    public partial class FrmAccountProperties : Form
    {
        public Account Account{ get; set; }
        public Connection Connection { get; set; }

        public FrmAccountProperties(Connection connection,int focusField, Account account = null)
        {
            InitializeComponent();

            Account = account;
            Connection = connection;

            if (account != null)
            {
                txtLabel.Text = account.Label;
                txtPassword.Text = account.Password;
            }

            if (focusField == 0)
            {
                txtLabel.Select();
            }
            else if (focusField == 1)
            {
                txtPassword.Select();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Finished();
        }

        private void Finished()
        {
            var password = txtPassword.Text;
            if (string.IsNullOrEmpty(password))
            {
                MessageBoxEx.Show(this, "Password cannot be blank", "Block Studio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtPassword.Enabled = false;
            btnOK.Enabled = false;
            btnCancel.Enabled = false;
            chbSavePassword.Enabled = false;

            if (Account==null)
            {
                Account = new Account();
                Account.Address = Connection.EthereumService.NewAccount(password);
            }

            Account.Password = password;
            Account.Label = txtLabel.Text;

            BlockStudioProjectService.BlockStudioProject.UpsertAccount(Account);
            BlockStudioProjectService.BlockStudioProject.SaveToDisk();

            this.Close();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Finished();
            }
        }
    }
}
