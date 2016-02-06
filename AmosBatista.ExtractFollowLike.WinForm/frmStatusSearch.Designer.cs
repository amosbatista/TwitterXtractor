namespace AmosBatista.ExtractFollowLike.WinForm
{
    partial class frmStatusSearch
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
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStatusAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the term to search";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(16, 30);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(170, 20);
            this.txtQuery.TabIndex = 1;
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(12, 129);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(207, 65);
            this.btnStartSearch.TabIndex = 2;
            this.btnStartSearch.Text = "Start search and save in the database";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "How much status do you want to search?";
            // 
            // txtStatusAmount
            // 
            this.txtStatusAmount.Location = new System.Drawing.Point(19, 84);
            this.txtStatusAmount.Name = "txtStatusAmount";
            this.txtStatusAmount.Size = new System.Drawing.Size(100, 20);
            this.txtStatusAmount.TabIndex = 4;
            // 
            // frmStatusSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 206);
            this.Controls.Add(this.txtStatusAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label1);
            this.Name = "frmStatusSearch";
            this.Text = "frmStatusSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStatusAmount;
    }
}