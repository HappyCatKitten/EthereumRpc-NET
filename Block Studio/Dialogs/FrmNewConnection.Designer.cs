namespace BlockStudio.Dialogs
{
    partial class FrmNewConnection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtAttachUrl = new System.Windows.Forms.TextBox();
            this.txtAttachPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.gbAttach = new System.Windows.Forms.GroupBox();
            this.rbAttach = new System.Windows.Forms.RadioButton();
            this.gbNewInstance = new System.Windows.Forms.GroupBox();
            this.rbCreateInstance = new System.Windows.Forms.RadioButton();
            this.txtNewInstancePort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbAttach.SuspendLayout();
            this.gbNewInstance.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blockchain provider";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 26);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(90, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Ethereum";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // txtAttachUrl
            // 
            this.txtAttachUrl.Location = new System.Drawing.Point(9, 60);
            this.txtAttachUrl.Name = "txtAttachUrl";
            this.txtAttachUrl.Size = new System.Drawing.Size(410, 22);
            this.txtAttachUrl.TabIndex = 1;
            this.txtAttachUrl.Text = "http://localhost";
            // 
            // txtAttachPort
            // 
            this.txtAttachPort.Location = new System.Drawing.Point(9, 109);
            this.txtAttachPort.Name = "txtAttachPort";
            this.txtAttachPort.Size = new System.Drawing.Size(111, 22);
            this.txtAttachPort.TabIndex = 2;
            this.txtAttachPort.Text = "8545";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(277, 474);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 35);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(385, 474);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(169, 474);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(102, 35);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "&Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // gbAttach
            // 
            this.gbAttach.Controls.Add(this.rbAttach);
            this.gbAttach.Controls.Add(this.txtAttachUrl);
            this.gbAttach.Controls.Add(this.txtAttachPort);
            this.gbAttach.Controls.Add(this.label1);
            this.gbAttach.Controls.Add(this.label2);
            this.gbAttach.Location = new System.Drawing.Point(12, 131);
            this.gbAttach.Name = "gbAttach";
            this.gbAttach.Size = new System.Drawing.Size(472, 146);
            this.gbAttach.TabIndex = 10;
            this.gbAttach.TabStop = false;
            // 
            // rbAttach
            // 
            this.rbAttach.AutoSize = true;
            this.rbAttach.Location = new System.Drawing.Point(9, 16);
            this.rbAttach.Name = "rbAttach";
            this.rbAttach.Size = new System.Drawing.Size(69, 21);
            this.rbAttach.TabIndex = 10;
            this.rbAttach.TabStop = true;
            this.rbAttach.Text = "Attach";
            this.rbAttach.UseVisualStyleBackColor = true;
            this.rbAttach.CheckedChanged += new System.EventHandler(this.rbAttach_CheckedChanged);
            // 
            // gbNewInstance
            // 
            this.gbNewInstance.Controls.Add(this.rbCreateInstance);
            this.gbNewInstance.Controls.Add(this.txtNewInstancePort);
            this.gbNewInstance.Controls.Add(this.label6);
            this.gbNewInstance.Location = new System.Drawing.Point(12, 283);
            this.gbNewInstance.Name = "gbNewInstance";
            this.gbNewInstance.Size = new System.Drawing.Size(472, 107);
            this.gbNewInstance.TabIndex = 12;
            this.gbNewInstance.TabStop = false;
            // 
            // rbCreateInstance
            // 
            this.rbCreateInstance.AutoSize = true;
            this.rbCreateInstance.Location = new System.Drawing.Point(9, 16);
            this.rbCreateInstance.Name = "rbCreateInstance";
            this.rbCreateInstance.Size = new System.Drawing.Size(128, 21);
            this.rbCreateInstance.TabIndex = 10;
            this.rbCreateInstance.TabStop = true;
            this.rbCreateInstance.Text = "Create Instance";
            this.rbCreateInstance.UseVisualStyleBackColor = true;
            this.rbCreateInstance.CheckedChanged += new System.EventHandler(this.rbCreateInstance_CheckedChanged);
            // 
            // txtNewInstancePort
            // 
            this.txtNewInstancePort.Location = new System.Drawing.Point(15, 60);
            this.txtNewInstancePort.Name = "txtNewInstancePort";
            this.txtNewInstancePort.Size = new System.Drawing.Size(111, 22);
            this.txtNewInstancePort.TabIndex = 2;
            this.txtNewInstancePort.Text = "8545";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(19, 94);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(410, 22);
            this.txtName.TabIndex = 13;
            this.txtName.Text = "New Connection";
            // 
            // FrmNewConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 521);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.gbNewInstance);
            this.Controls.Add(this.gbAttach);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewConnection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Connection";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbAttach.ResumeLayout(false);
            this.gbAttach.PerformLayout();
            this.gbNewInstance.ResumeLayout(false);
            this.gbNewInstance.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtAttachUrl;
        private System.Windows.Forms.TextBox txtAttachPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox gbAttach;
        private System.Windows.Forms.RadioButton rbAttach;
        private System.Windows.Forms.GroupBox gbNewInstance;
        private System.Windows.Forms.RadioButton rbCreateInstance;
        private System.Windows.Forms.TextBox txtNewInstancePort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
    }
}