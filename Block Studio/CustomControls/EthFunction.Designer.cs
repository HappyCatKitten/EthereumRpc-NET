namespace BlockStudio.CustomControls
{
    partial class EthFunction
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
            this.lblFunctionName = new System.Windows.Forms.Label();
            this.fpInputs = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lblFunctionName
            // 
            this.lblFunctionName.AutoSize = true;
            this.lblFunctionName.Location = new System.Drawing.Point(13, 9);
            this.lblFunctionName.Name = "lblFunctionName";
            this.lblFunctionName.Size = new System.Drawing.Size(0, 17);
            this.lblFunctionName.TabIndex = 0;
            // 
            // fpInputs
            // 
            this.fpInputs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpInputs.Location = new System.Drawing.Point(8, 43);
            this.fpInputs.Name = "fpInputs";
            this.fpInputs.Size = new System.Drawing.Size(353, 94);
            this.fpInputs.TabIndex = 1;
            // 
            // EthFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.fpInputs);
            this.Controls.Add(this.lblFunctionName);
            this.Name = "EthFunction";
            this.Size = new System.Drawing.Size(368, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFunctionName;
        private System.Windows.Forms.FlowLayoutPanel fpInputs;
    }
}
