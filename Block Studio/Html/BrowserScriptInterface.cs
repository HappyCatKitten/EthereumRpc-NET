using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EthereumRpc;

namespace BlockStudio.Html
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class BrowserScriptInterface
    {
        public WebBrowser WebBrowser { get; set; }
        public EthereumService EthereumService { get; set; }

        public void LoadTransaction(string txHash)
        {
            var tx = EthereumService.GetTransactionByHash(txHash);
            WebBrowser.DocumentText = HtmlService.TransactionHtml(tx);
        } 
    }
}
