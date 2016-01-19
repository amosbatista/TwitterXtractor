namespace AmosBatista.ExtractFollowLike.WinForm
{
    partial class frmStatusList
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
            this.btnGenerateList = new System.Windows.Forms.Button();
            this.txtScreenName = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtRTResult = new System.Windows.Forms.TextBox();
            this.txtPostId = new System.Windows.Forms.TextBox();
            this.btnGenerateRT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGenerateList
            // 
            this.btnGenerateList.Location = new System.Drawing.Point(13, 39);
            this.btnGenerateList.Name = "btnGenerateList";
            this.btnGenerateList.Size = new System.Drawing.Size(153, 23);
            this.btnGenerateList.TabIndex = 0;
            this.btnGenerateList.Text = "Get posts from user above";
            this.btnGenerateList.UseVisualStyleBackColor = true;
            this.btnGenerateList.Click += new System.EventHandler(this.btnGenerateList_Click);
            // 
            // txtScreenName
            // 
            this.txtScreenName.Location = new System.Drawing.Point(13, 13);
            this.txtScreenName.Name = "txtScreenName";
            this.txtScreenName.Size = new System.Drawing.Size(100, 20);
            this.txtScreenName.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(13, 69);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(276, 192);
            this.txtResult.TabIndex = 2;
            // 
            // txtRTResult
            // 
            this.txtRTResult.Location = new System.Drawing.Point(374, 69);
            this.txtRTResult.Multiline = true;
            this.txtRTResult.Name = "txtRTResult";
            this.txtRTResult.Size = new System.Drawing.Size(276, 192);
            this.txtRTResult.TabIndex = 5;
            // 
            // txtPostId
            // 
            this.txtPostId.Location = new System.Drawing.Point(374, 13);
            this.txtPostId.Name = "txtPostId";
            this.txtPostId.Size = new System.Drawing.Size(100, 20);
            this.txtPostId.TabIndex = 4;
            // 
            // btnGenerateRT
            // 
            this.btnGenerateRT.Location = new System.Drawing.Point(374, 39);
            this.btnGenerateRT.Name = "btnGenerateRT";
            this.btnGenerateRT.Size = new System.Drawing.Size(190, 23);
            this.btnGenerateRT.TabIndex = 3;
            this.btnGenerateRT.Text = "Get posts retwitters from post above";
            this.btnGenerateRT.UseVisualStyleBackColor = true;
            this.btnGenerateRT.Click += new System.EventHandler(this.btnGenerateRT_Click);
            // 
            // frmStatusList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 280);
            this.Controls.Add(this.txtRTResult);
            this.Controls.Add(this.txtPostId);
            this.Controls.Add(this.btnGenerateRT);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtScreenName);
            this.Controls.Add(this.btnGenerateList);
            this.Name = "frmStatusList";
            this.Text = "frmStatusList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateList;
        private System.Windows.Forms.TextBox txtScreenName;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtRTResult;
        private System.Windows.Forms.TextBox txtPostId;
        private System.Windows.Forms.Button btnGenerateRT;
    }
}