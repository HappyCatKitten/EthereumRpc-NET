namespace BlockStudio.Dialogs
{
    partial class FrmNewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewProject));
            this.label1 = new System.Windows.Forms.Label();
            this.pgOptions = new System.Windows.Forms.PropertyGrid();
            this.lvCreate = new System.Windows.Forms.ListView();
            this.ilIcons = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtProjectLocation = new System.Windows.Forms.TextBox();
            this.lblProjectName = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.btnBrowseLocation = new System.Windows.Forms.Button();
            this.fdSelectLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(627, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Create a new Instance or attach to an existing Ethereum instance";
            // 
            // pgOptions
            // 
            this.pgOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgOptions.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pgOptions.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.pgOptions.Location = new System.Drawing.Point(394, 40);
            this.pgOptions.Name = "pgOptions";
            this.pgOptions.Size = new System.Drawing.Size(478, 424);
            this.pgOptions.TabIndex = 4;
            // 
            // lvCreate
            // 
            this.lvCreate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvCreate.HideSelection = false;
            this.lvCreate.LargeImageList = this.ilIcons;
            this.lvCreate.Location = new System.Drawing.Point(15, 40);
            this.lvCreate.Name = "lvCreate";
            this.lvCreate.Size = new System.Drawing.Size(372, 424);
            this.lvCreate.TabIndex = 3;
            this.lvCreate.UseCompatibleStateImageBehavior = false;
            this.lvCreate.SelectedIndexChanged += new System.EventHandler(this.lvCreate_SelectedIndexChanged);
            // 
            // ilIcons
            // 
            this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
            this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilIcons.Images.SetKeyName(0, "Ethereum.png");
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(644, 551);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(528, 551);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 35);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtProjectLocation
            // 
            this.txtProjectLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectLocation.Location = new System.Drawing.Point(105, 518);
            this.txtProjectLocation.Name = "txtProjectLocation";
            this.txtProjectLocation.Size = new System.Drawing.Size(296, 24);
            this.txtProjectLocation.TabIndex = 8;
            // 
            // lblProjectName
            // 
            this.lblProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(12, 518);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(62, 17);
            this.lblProjectName.TabIndex = 9;
            this.lblProjectName.Text = "Location";
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(760, 551);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(110, 35);
            this.btnTest.TabIndex = 10;
            this.btnTest.Text = "&Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Project Name";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectName.Location = new System.Drawing.Point(105, 478);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(296, 24);
            this.txtProjectName.TabIndex = 11;
            // 
            // btnBrowseLocation
            // 
            this.btnBrowseLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseLocation.Location = new System.Drawing.Point(407, 509);
            this.btnBrowseLocation.Name = "btnBrowseLocation";
            this.btnBrowseLocation.Size = new System.Drawing.Size(110, 35);
            this.btnBrowseLocation.TabIndex = 13;
            this.btnBrowseLocation.Text = "&Browse";
            this.btnBrowseLocation.UseVisualStyleBackColor = true;
            this.btnBrowseLocation.Click += new System.EventHandler(this.btnBrowseLocation_Click);
            // 
            // FrmNewProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 598);
            this.Controls.Add(this.btnBrowseLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lblProjectName);
            this.Controls.Add(this.txtProjectLocation);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pgOptions);
            this.Controls.Add(this.lvCreate);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(900, 676);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 568);
            this.Name = "FrmNewProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Block Studio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PropertyGrid pgOptions;
        private System.Windows.Forms.ListView lvCreate;
        private System.Windows.Forms.ImageList ilIcons;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtProjectLocation;
        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnBrowseLocation;
        private System.Windows.Forms.FolderBrowserDialog fdSelectLocation;
    }
}