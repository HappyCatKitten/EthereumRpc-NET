using FastColoredTextBoxNS;

namespace BlockStudio.CustomControls
{
    partial class ConnectionPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionPanel));
            this.pbBlockChainSyncing = new System.Windows.Forms.ProgressBar();
            this.lblBlockChainStatus = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabBlockchain = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGetCode = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEstimateGas = new System.Windows.Forms.TextBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.fpAbi = new System.Windows.Forms.FlowLayoutPanel();
            this.tabFiles = new System.Windows.Forms.TabPage();
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.fsSource = new FastColoredTextBoxNS.FastColoredTextBox();
            this.txtBuildOutput = new System.Windows.Forms.TextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.tabControl2.SuspendLayout();
            this.tabBlockchain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fsSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBlockChainSyncing
            // 
            this.pbBlockChainSyncing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbBlockChainSyncing.Location = new System.Drawing.Point(4, 643);
            this.pbBlockChainSyncing.Name = "pbBlockChainSyncing";
            this.pbBlockChainSyncing.Size = new System.Drawing.Size(169, 20);
            this.pbBlockChainSyncing.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbBlockChainSyncing.TabIndex = 4;
            // 
            // lblBlockChainStatus
            // 
            this.lblBlockChainStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBlockChainStatus.AutoSize = true;
            this.lblBlockChainStatus.Location = new System.Drawing.Point(180, 644);
            this.lblBlockChainStatus.Name = "lblBlockChainStatus";
            this.lblBlockChainStatus.Size = new System.Drawing.Size(0, 17);
            this.lblBlockChainStatus.TabIndex = 5;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "refresh.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(67, 4);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabBlockchain);
            this.tabControl2.Controls.Add(this.tabFiles);
            this.tabControl2.Location = new System.Drawing.Point(984, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(429, 437);
            this.tabControl2.TabIndex = 12;
            // 
            // tabBlockchain
            // 
            this.tabBlockchain.Controls.Add(this.groupBox2);
            this.tabBlockchain.Controls.Add(this.fpAbi);
            this.tabBlockchain.Location = new System.Drawing.Point(4, 25);
            this.tabBlockchain.Name = "tabBlockchain";
            this.tabBlockchain.Padding = new System.Windows.Forms.Padding(3);
            this.tabBlockchain.Size = new System.Drawing.Size(421, 408);
            this.tabBlockchain.TabIndex = 1;
            this.tabBlockchain.Text = "BlockChain";
            this.tabBlockchain.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGetCode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.cmbAccounts);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtEstimateGas);
            this.groupBox2.Controls.Add(this.btnPublish);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 119);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btnGetCode
            // 
            this.btnGetCode.Location = new System.Drawing.Point(18, 70);
            this.btnGetCode.Name = "btnGetCode";
            this.btnGetCode.Size = new System.Drawing.Size(121, 35);
            this.btnGetCode.TabIndex = 22;
            this.btnGetCode.Text = "Get Code";
            this.btnGetCode.UseVisualStyleBackColor = true;
            this.btnGetCode.Click += new System.EventHandler(this.btnGetCode_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Account";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.ImageKey = "refresh.png";
            this.btnRefresh.ImageList = this.imageList1;
            this.btnRefresh.Location = new System.Drawing.Point(341, 37);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(36, 24);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(156, 38);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(179, 24);
            this.cmbAccounts.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estimated Gas";
            // 
            // txtEstimateGas
            // 
            this.txtEstimateGas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstimateGas.Location = new System.Drawing.Point(18, 38);
            this.txtEstimateGas.Name = "txtEstimateGas";
            this.txtEstimateGas.Size = new System.Drawing.Size(121, 24);
            this.txtEstimateGas.TabIndex = 1;
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(256, 70);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(121, 35);
            this.btnPublish.TabIndex = 0;
            this.btnPublish.Text = "&Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // fpAbi
            // 
            this.fpAbi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fpAbi.AutoScroll = true;
            this.fpAbi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpAbi.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpAbi.Location = new System.Drawing.Point(6, 132);
            this.fpAbi.Name = "fpAbi";
            this.fpAbi.Size = new System.Drawing.Size(409, 270);
            this.fpAbi.TabIndex = 5;
            // 
            // tabFiles
            // 
            this.tabFiles.Controls.Add(this.tvFiles);
            this.tabFiles.Location = new System.Drawing.Point(4, 25);
            this.tabFiles.Name = "tabFiles";
            this.tabFiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabFiles.Size = new System.Drawing.Size(421, 408);
            this.tabFiles.TabIndex = 0;
            this.tabFiles.Text = "Generated files";
            this.tabFiles.UseVisualStyleBackColor = true;
            // 
            // tvFiles
            // 
            this.tvFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFiles.Location = new System.Drawing.Point(6, 6);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.Size = new System.Drawing.Size(391, 345);
            this.tvFiles.TabIndex = 3;
            // 
            // fsSource
            // 
            this.fsSource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fsSource.AutoCompleteBracketsList = new char[] {
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
            this.fsSource.AutoScrollMinSize = new System.Drawing.Size(551, 90);
            this.fsSource.BackBrush = null;
            this.fsSource.CharHeight = 18;
            this.fsSource.CharWidth = 10;
            this.fsSource.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fsSource.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fsSource.IsReplaceMode = false;
            this.fsSource.Location = new System.Drawing.Point(4, 2);
            this.fsSource.Name = "fsSource";
            this.fsSource.Paddings = new System.Windows.Forms.Padding(0);
            this.fsSource.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fsSource.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fsSource.ServiceColors")));
            this.fsSource.ShowFoldingLines = true;
            this.fsSource.Size = new System.Drawing.Size(974, 437);
            this.fsSource.SourceTextBox = this.fsSource;
            this.fsSource.TabIndex = 11;
            this.fsSource.Text = "contract Test {\r\n    function get() constant returns (uint8 retVal) {\r\n        re" +
    "turn 1;\r\n    }\r\n}";
            this.fsSource.Zoom = 100;
            // 
            // txtBuildOutput
            // 
            this.txtBuildOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuildOutput.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtBuildOutput.Location = new System.Drawing.Point(4, 445);
            this.txtBuildOutput.Multiline = true;
            this.txtBuildOutput.Name = "txtBuildOutput";
            this.txtBuildOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBuildOutput.Size = new System.Drawing.Size(1409, 176);
            this.txtBuildOutput.TabIndex = 10;
            // 
            // btnBuild
            // 
            this.btnBuild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuild.Location = new System.Drawing.Point(1272, 627);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(141, 39);
            this.btnBuild.TabIndex = 9;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // ConnectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.fsSource);
            this.Controls.Add(this.txtBuildOutput);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.lblBlockChainStatus);
            this.Controls.Add(this.pbBlockChainSyncing);
            this.Name = "ConnectionPanel";
            this.Size = new System.Drawing.Size(1416, 669);
            this.tabControl2.ResumeLayout(false);
            this.tabBlockchain.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fsSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbBlockChainSyncing;
        private System.Windows.Forms.Label lblBlockChainStatus;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabBlockchain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEstimateGas;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.FlowLayoutPanel fpAbi;
        private System.Windows.Forms.TabPage tabFiles;
        private System.Windows.Forms.TreeView tvFiles;
        private FastColoredTextBox fsSource;
        private System.Windows.Forms.TextBox txtBuildOutput;
        private System.Windows.Forms.Button btnBuild;
    }
}
