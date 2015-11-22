using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EthereumRpc;

namespace Ethereum.Wallet
{
    public partial class FrmUnlock : Form
    {
        public EthereumService EthereumService { get; set; }
        public string Account{ get; set; }
        public FrmUnlock(string account, EthereumService ethereumService)
        {
            EthereumService = ethereumService;
            Account = account;

            
            InitializeComponent();

            
            this.txtPassword.HandleCreated += TxtPassword_HandleCreated;
        }

        private void TxtPassword_HandleCreated(object sender, EventArgs e)
        {
            txtPassword.Focus();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            var result = EthereumService.UnlockAccount(Account, txtPassword.Text);

            if (!result)
            {
                MessageBox.Show("Incorrect password");
            }
            else
            {
                this.Close();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                btnUnlock.PerformClick();
            }
        }
    }
}
