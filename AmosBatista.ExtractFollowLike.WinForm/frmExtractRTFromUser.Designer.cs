namespace AmosBatista.ExtractFollowLike.WinForm
{
    partial class frmExtractRTFromUser
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
            this.txtTwitterUser = new System.Windows.Forms.TextBox();
            this.btnExtract = new System.Windows.Forms.Button();
            this.prograssBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Twitter User @";
            // 
            // txtTwitterUser
            // 
            this.txtTwitterUser.Location = new System.Drawing.Point(98, 13);
            this.txtTwitterUser.Name = "txtTwitterUser";
            this.txtTwitterUser.Size = new System.Drawing.Size(169, 20);
            this.txtTwitterUser.TabIndex = 1;
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(16, 47);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(251, 23);
            this.btnExtract.TabIndex = 2;
            this.btnExtract.Text = "Extract to DataBase";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // prograssBar
            // 
            this.prograssBar.Location = new System.Drawing.Point(16, 77);
            this.prograssBar.Name = "prograssBar";
            this.prograssBar.Size = new System.Drawing.Size(251, 23);
            this.prograssBar.TabIndex = 3;
            // 
            // frmExtractRTFromUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 114);
            this.Controls.Add(this.prograssBar);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.txtTwitterUser);
            this.Controls.Add(this.label1);
            this.Name = "frmExtractRTFromUser";
            this.Text = "Extract of RT from an User";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTwitterUser;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.ProgressBar prograssBar;
    }
}