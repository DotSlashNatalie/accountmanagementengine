namespace QRWin
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnMakeQR = new System.Windows.Forms.Button();
            this.qrCon1 = new Gma.QrCodeNet.Encoding.Windows.Controls.QrCodeControl();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(110, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(310, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(110, 35);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(310, 20);
            this.txtKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name/Label";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Secret Key";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(426, 35);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 4;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnMakeQR
            // 
            this.btnMakeQR.Location = new System.Drawing.Point(22, 67);
            this.btnMakeQR.Name = "btnMakeQR";
            this.btnMakeQR.Size = new System.Drawing.Size(479, 35);
            this.btnMakeQR.TabIndex = 6;
            this.btnMakeQR.Text = "Make QR Code";
            this.btnMakeQR.UseVisualStyleBackColor = true;
            this.btnMakeQR.Click += new System.EventHandler(this.btnMakeQR_Click);
            // 
            // qrCon1
            // 
            this.qrCon1.AutoSize = true;
            this.qrCon1.Location = new System.Drawing.Point(22, 108);
            this.qrCon1.Name = "qrCon1";
            this.qrCon1.Size = new System.Drawing.Size(204, 204);
            this.qrCon1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 539);
            this.Controls.Add(this.qrCon1);
            this.Controls.Add(this.btnMakeQR);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.txtName);
            this.Name = "Form1";
            this.Text = "QRWin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnMakeQR;
        private Gma.QrCodeNet.Encoding.Windows.Controls.QrCodeControl qrCon1;
    }
}

