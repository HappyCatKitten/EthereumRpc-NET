using BlockStudio.CustomControls;

namespace BlockStudio
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tvConnections = new System.Windows.Forms.TreeView();
            this.ilConnectionTree = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabContract = new System.Windows.Forms.TabPage();
            this.connectionPanel1 = new BlockStudio.CustomControls.ConnectionPanel();
            this.tabHtmlEdit = new System.Windows.Forms.TabPage();
            this.txtHtmlEditor = new FastColoredTextBoxNS.FastColoredTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ConnectionNodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.LaunchInstanceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameConnectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountParentContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AccountContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.unlockAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.signToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabContract.SuspendLayout();
            this.tabHtmlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHtmlEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ConnectionNodeContextMenu.SuspendLayout();
            this.AccountParentContextMenuStrip.SuspendLayout();
            this.AccountContextMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.addressMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvConnections
            // 
            this.tvConnections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvConnections.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvConnections.ImageIndex = 0;
            this.tvConnections.ImageList = this.ilConnectionTree;
            this.tvConnections.ItemHeight = 25;
            this.tvConnections.Location = new System.Drawing.Point(0, 0);
            this.tvConnections.Name = "tvConnections";
            this.tvConnections.SelectedImageIndex = 0;
            this.tvConnections.Size = new System.Drawing.Size(285, 643);
            this.tvConnections.TabIndex = 0;
            // 
            // ilConnectionTree
            // 
            this.ilConnectionTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilConnectionTree.ImageStream")));
            this.ilConnectionTree.TransparentColor = System.Drawing.Color.Transparent;
            this.ilConnectionTree.Images.SetKeyName(0, "NewConnection.png");
            this.ilConnectionTree.Images.SetKeyName(1, "Ethereum.png");
            this.ilConnectionTree.Images.SetKeyName(2, "Account.png");
            this.ilConnectionTree.Images.SetKeyName(3, "locked.png");
            this.ilConnectionTree.Images.SetKeyName(4, "unlocked.png");
            this.ilConnectionTree.Images.SetKeyName(5, "waiting.png");
            this.ilConnectionTree.Images.SetKeyName(6, "IncorrectPassword.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabContract);
            this.tabControl1.Controls.Add(this.tabHtmlEdit);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1001, 643);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Visible = false;
            // 
            // tabContract
            // 
            this.tabContract.Controls.Add(this.connectionPanel1);
            this.tabContract.Location = new System.Drawing.Point(4, 25);
            this.tabContract.Name = "tabContract";
            this.tabContract.Size = new System.Drawing.Size(993, 614);
            this.tabContract.TabIndex = 1;
            this.tabContract.Text = "Contract";
            this.tabContract.UseVisualStyleBackColor = true;
            // 
            // connectionPanel1
            // 
            this.connectionPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.connectionPanel1.BlockStudioProjectService = null;
            this.connectionPanel1.Location = new System.Drawing.Point(3, 3);
            this.connectionPanel1.Name = "connectionPanel1";
            this.connectionPanel1.Size = new System.Drawing.Size(990, 608);
            this.connectionPanel1.TabIndex = 0;
            // 
            // tabHtmlEdit
            // 
            this.tabHtmlEdit.Controls.Add(this.txtHtmlEditor);
            this.tabHtmlEdit.Location = new System.Drawing.Point(4, 25);
            this.tabHtmlEdit.Name = "tabHtmlEdit";
            this.tabHtmlEdit.Size = new System.Drawing.Size(993, 614);
            this.tabHtmlEdit.TabIndex = 0;
            this.tabHtmlEdit.Text = "Html Editor";
            this.tabHtmlEdit.UseVisualStyleBackColor = true;
            // 
            // txtHtmlEditor
            // 
            this.txtHtmlEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHtmlEditor.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtHtmlEditor.AutoIndentCharsPatterns = "";
            this.txtHtmlEditor.AutoScrollMinSize = new System.Drawing.Size(2, 18);
            this.txtHtmlEditor.BackBrush = null;
            this.txtHtmlEditor.CharHeight = 18;
            this.txtHtmlEditor.CharWidth = 10;
            this.txtHtmlEditor.CommentPrefix = null;
            this.txtHtmlEditor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHtmlEditor.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtHtmlEditor.IsReplaceMode = false;
            this.txtHtmlEditor.Language = FastColoredTextBoxNS.Language.HTML;
            this.txtHtmlEditor.LeftBracket = '<';
            this.txtHtmlEditor.LeftBracket2 = '(';
            this.txtHtmlEditor.Location = new System.Drawing.Point(3, 3);
            this.txtHtmlEditor.Name = "txtHtmlEditor";
            this.txtHtmlEditor.Paddings = new System.Windows.Forms.Padding(0);
            this.txtHtmlEditor.RightBracket = '>';
            this.txtHtmlEditor.RightBracket2 = ')';
            this.txtHtmlEditor.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtHtmlEditor.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtHtmlEditor.ServiceColors")));
            this.txtHtmlEditor.Size = new System.Drawing.Size(987, 585);
            this.txtHtmlEditor.SourceTextBox = this.txtHtmlEditor;
            this.txtHtmlEditor.TabIndex = 0;
            this.txtHtmlEditor.Zoom = 100;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvConnections);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1296, 646);
            this.splitContainer1.SplitterDistance = 288;
            this.splitContainer1.TabIndex = 1;
            // 
            // ConnectionNodeContextMenu
            // 
            this.ConnectionNodeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ConnectionNodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.deleteConnectionToolStripMenuItem,
            this.renameConnectionToolStripMenuItem,
            this.LaunchInstanceMenuItem,
            this.renameConnectionToolStripMenuItem1,
            this.propertiesToolStripMenuItem});
            this.ConnectionNodeContextMenu.Name = "ConnectionNodeContextMenu";
            this.ConnectionNodeContextMenu.Size = new System.Drawing.Size(218, 140);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.refreshToolStripMenuItem.Text = "&Connect";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // deleteConnectionToolStripMenuItem
            // 
            this.deleteConnectionToolStripMenuItem.Name = "deleteConnectionToolStripMenuItem";
            this.deleteConnectionToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.deleteConnectionToolStripMenuItem.Text = "&Delete Connection";
            this.deleteConnectionToolStripMenuItem.Click += new System.EventHandler(this.deleteConnectionToolStripMenuItem_Click);
            // 
            // renameConnectionToolStripMenuItem
            // 
            this.renameConnectionToolStripMenuItem.Name = "renameConnectionToolStripMenuItem";
            this.renameConnectionToolStripMenuItem.Size = new System.Drawing.Size(214, 6);
            this.renameConnectionToolStripMenuItem.Click += new System.EventHandler(this.renameConnectionToolStripMenuItem_Click);
            // 
            // LaunchInstanceMenuItem
            // 
            this.LaunchInstanceMenuItem.Name = "LaunchInstanceMenuItem";
            this.LaunchInstanceMenuItem.Size = new System.Drawing.Size(217, 26);
            this.LaunchInstanceMenuItem.Text = "&Launch Instance";
            this.LaunchInstanceMenuItem.Click += new System.EventHandler(this.LaunchInstanceMenuItem_Click);
            // 
            // renameConnectionToolStripMenuItem1
            // 
            this.renameConnectionToolStripMenuItem1.Name = "renameConnectionToolStripMenuItem1";
            this.renameConnectionToolStripMenuItem1.Size = new System.Drawing.Size(217, 26);
            this.renameConnectionToolStripMenuItem1.Text = "&Rename Connection";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(217, 26);
            this.propertiesToolStripMenuItem.Text = "&Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // AccountParentContextMenuStrip
            // 
            this.AccountParentContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AccountParentContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAccountToolStripMenuItem});
            this.AccountParentContextMenuStrip.Name = "AccountParentContextMenuStrip";
            this.AccountParentContextMenuStrip.Size = new System.Drawing.Size(173, 30);
            // 
            // newAccountToolStripMenuItem
            // 
            this.newAccountToolStripMenuItem.Name = "newAccountToolStripMenuItem";
            this.newAccountToolStripMenuItem.Size = new System.Drawing.Size(172, 26);
            this.newAccountToolStripMenuItem.Text = "&New Account";
            this.newAccountToolStripMenuItem.Click += new System.EventHandler(this.newAccountToolStripMenuItem_Click);
            // 
            // AccountContextMenuStrip
            // 
            this.AccountContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AccountContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unlockAccountToolStripMenuItem,
            this.lockAccountToolStripMenuItem,
            this.toolStripSeparator1,
            this.signToolStripMenuItem,
            this.renameAccountToolStripMenuItem});
            this.AccountContextMenuStrip.Name = "AccountContextMenuStrip";
            this.AccountContextMenuStrip.Size = new System.Drawing.Size(210, 114);
            // 
            // unlockAccountToolStripMenuItem
            // 
            this.unlockAccountToolStripMenuItem.Name = "unlockAccountToolStripMenuItem";
            this.unlockAccountToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.unlockAccountToolStripMenuItem.Text = "&Unlock Account";
            this.unlockAccountToolStripMenuItem.Click += new System.EventHandler(this.unlockAccountToolStripMenuItem_Click);
            // 
            // lockAccountToolStripMenuItem
            // 
            this.lockAccountToolStripMenuItem.Name = "lockAccountToolStripMenuItem";
            this.lockAccountToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.lockAccountToolStripMenuItem.Text = "&Lock Account";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
            // 
            // signToolStripMenuItem
            // 
            this.signToolStripMenuItem.Name = "signToolStripMenuItem";
            this.signToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.signToolStripMenuItem.Text = "&Sign";
            // 
            // renameAccountToolStripMenuItem
            // 
            this.renameAccountToolStripMenuItem.Name = "renameAccountToolStripMenuItem";
            this.renameAccountToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.renameAccountToolStripMenuItem.Text = "Account &Properties";
            this.renameAccountToolStripMenuItem.Click += new System.EventHandler(this.renameAccountToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1295, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newProjectToolStripMenuItem
            // 
            this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
            this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.newProjectToolStripMenuItem.Text = "&New Project";
            this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.newConnectionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 6);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(164, 26);
            this.exitToolStripMenuItem1.Text = "&Exit";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(57, 24);
            this.toolStripMenuItem2.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.HelpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // addressMenuStrip
            // 
            this.addressMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.addressMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAddressToolStripMenuItem});
            this.addressMenuStrip.Name = "contextMenuStrip1";
            this.addressMenuStrip.Size = new System.Drawing.Size(176, 30);
            // 
            // copyAddressToolStripMenuItem
            // 
            this.copyAddressToolStripMenuItem.Name = "copyAddressToolStripMenuItem";
            this.copyAddressToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.copyAddressToolStripMenuItem.Text = "&Copy Address";
            this.copyAddressToolStripMenuItem.Click += new System.EventHandler(this.copyAddressToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 677);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Block Studio";
            this.tabControl1.ResumeLayout(false);
            this.tabContract.ResumeLayout(false);
            this.tabHtmlEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHtmlEditor)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ConnectionNodeContextMenu.ResumeLayout(false);
            this.AccountParentContextMenuStrip.ResumeLayout(false);
            this.AccountContextMenuStrip.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.addressMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView tvConnections;
        private System.Windows.Forms.ImageList ilConnectionTree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip ConnectionNodeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator renameConnectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameConnectionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LaunchInstanceMenuItem;
        private System.Windows.Forms.ContextMenuStrip AccountParentContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newAccountToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip AccountContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem unlockAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockAccountToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameAccountToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem signToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip addressMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyAddressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.TabPage tabHtmlEdit;
        private FastColoredTextBoxNS.FastColoredTextBox txtHtmlEditor;
        private System.Windows.Forms.TabPage tabContract;
        private ConnectionPanel connectionPanel1;
    }
}

