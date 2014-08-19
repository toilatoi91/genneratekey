namespace GennerateKey
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProducKey = new System.Windows.Forms.TextBox();
            this.txtLicenceKey = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã máy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Key";
            // 
            // txtProducKey
            // 
            this.txtProducKey.Location = new System.Drawing.Point(76, 33);
            this.txtProducKey.Name = "txtProducKey";
            this.txtProducKey.Size = new System.Drawing.Size(195, 20);
            this.txtProducKey.TabIndex = 2;
            this.txtProducKey.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtLicenceKey
            // 
            this.txtLicenceKey.Location = new System.Drawing.Point(76, 59);
            this.txtLicenceKey.Name = "txtLicenceKey";
            this.txtLicenceKey.Size = new System.Drawing.Size(195, 20);
            this.txtLicenceKey.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 121);
            this.Controls.Add(this.txtLicenceKey);
            this.Controls.Add(this.txtProducKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProducKey;
        private System.Windows.Forms.TextBox txtLicenceKey;
    }
}

