namespace BlockStudio.Dialogs
{
    partial class FrmOptions
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
            this.btnOpenProjects = new System.Windows.Forms.Button();
            this.btnOpenExe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenProjects
            // 
            this.btnOpenProjects.Location = new System.Drawing.Point(330, 25);
            this.btnOpenProjects.Name = "btnOpenProjects";
            this.btnOpenProjects.Size = new System.Drawing.Size(184, 44);
            this.btnOpenProjects.TabIndex = 0;
            this.btnOpenProjects.Text = "Open Projects folder";
            this.btnOpenProjects.UseVisualStyleBackColor = true;
            this.btnOpenProjects.Click += new System.EventHandler(this.btnOpenProjects_Click);
            // 
            // btnOpenExe
            // 
            this.btnOpenExe.Location = new System.Drawing.Point(330, 88);
            this.btnOpenExe.Name = "btnOpenExe";
            this.btnOpenExe.Size = new System.Drawing.Size(184, 44);
            this.btnOpenExe.TabIndex = 1;
            this.btnOpenExe.Text = "Open Exe folder";
            this.btnOpenExe.UseVisualStyleBackColor = true;
            this.btnOpenExe.Click += new System.EventHandler(this.btnOpenExe_Click);
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 475);
            this.Controls.Add(this.btnOpenExe);
            this.Controls.Add(this.btnOpenProjects);
            this.Name = "FrmOptions";
            this.Text = "Block Studio Options";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenProjects;
        private System.Windows.Forms.Button btnOpenExe;
    }
}