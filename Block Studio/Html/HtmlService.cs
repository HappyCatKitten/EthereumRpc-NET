using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EthereumRpc.Ethereum;
using EthereumRpc.RpcObjects;

namespace BlockStudio.Html
{
    public class HtmlService
    { 
        private static string Header()
        {
            return "<html><body oncontextmenu='return false'><style>body {padding - top: 50px; padding - bottom: 20px;font-family:arial;</style>";
        }

        private static string Footer()
        {
            return "</body></html>";
        }

        public static string TransactionHtml(Transaction tx)
        {
            var html = Header();

            html += string.Format("<div>Hash : {0}</div>", tx.Hash);
            html += string.Format("<div>Nonce : {0}</div>", tx.Nonce);
            html += string.Format("<div>From : {0}</div>", tx.From);
            html += string.Format("<div>To : {0}</div>", tx.To);

            html += Footer();

            return html;
        }

        public static string NoResults()
        {
            var html = Header();

            html += string.Format("No objects found");

            html += Footer();

            return html;
        }

        public static string BlockHtml(Block block)
        {
            var html = Header();

            html += string.Format("<div>Number : {0}</div>", block.Number);
            html += string.Format("<div>Hash : {0}</div>", block.Hash);
            html += string.Format("<div>Difficulty : {0}</div>", block.Difficulty);

            html += string.Format("<div>Transactions</div>");

            foreach (var tx in block.TransactionsFull)
            {
                html += string.Format(@"<div>tx hash : <a href='javascript:window.external.LoadTransaction(""{0}"");'>{0}</a></div>", tx.Hash);
                html += string.Format("<div>from: {0}</div>", tx.From);
                html += string.Format("<div>to: {0}</div>", tx.To);
            }

            html += "<br><br><input type=button onclick='window.external.callMe();' value='Call'>";

            html += Footer();

            return html;
        }
    }
}
