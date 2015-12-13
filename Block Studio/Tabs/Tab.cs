using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockStudio.CustomControls;
using BlockStudio.Project;

namespace BlockStudio.Tabs
{
    public class Tab : TabPage
    {
        public ConnectionPanel ConnectionPanel{ get; set; }

        public Tab()
        {
            ConnectionPanel = new ConnectionPanel();
            ConnectionPanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            ConnectionPanel.BorderStyle = BorderStyle.FixedSingle;
            ConnectionPanel.Width = this.Width;
            ConnectionPanel.Height = this.Height;
            
            this.Controls.Add(ConnectionPanel);
        }
    }
}
