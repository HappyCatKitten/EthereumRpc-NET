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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ConnectionNodeContextMenu.SuspendLayout();
            this.AccountParentContextMenuStrip.SuspendLayout();
            this.AccountContextMenuStrip.SuspendLayout();
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
            this.tvConnections.ItemHeight = 23;
            this.tvConnections.Location = new System.Drawing.Point(0, 0);
            this.tvConnections.Name = "tvConnections";
            this.tvConnections.SelectedImageIndex = 0;
            this.tvConnections.Size = new System.Drawing.Size(262, 670);
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
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 670);
            this.tabControl1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvConnections);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1296, 673);
            this.splitContainer1.SplitterDistance = 265;
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
            this.refreshToolStripMenuItem.Text = "&Refresh";
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
            this.lockAccountToolStripMenuItem});
            this.AccountContextMenuStrip.Name = "AccountContextMenuStrip";
            this.AccountContextMenuStrip.Size = new System.Drawing.Size(188, 84);
            // 
            // unlockAccountToolStripMenuItem
            // 
            this.unlockAccountToolStripMenuItem.Name = "unlockAccountToolStripMenuItem";
            this.unlockAccountToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.unlockAccountToolStripMenuItem.Text = "&Unlock Account";
            this.unlockAccountToolStripMenuItem.Click += new System.EventHandler(this.unlockAccountToolStripMenuItem_Click);
            // 
            // lockAccountToolStripMenuItem
            // 
            this.lockAccountToolStripMenuItem.Name = "lockAccountToolStripMenuItem";
            this.lockAccountToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.lockAccountToolStripMenuItem.Text = "&Lock Account";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 677);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Block Studio";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ConnectionNodeContextMenu.ResumeLayout(false);
            this.AccountParentContextMenuStrip.ResumeLayout(false);
            this.AccountContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}

