﻿namespace AmosBatista.ExtractFollowLike.WinForm
{
    partial class frmProcessUserNetwork
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
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeepNess = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chkExtractHalfList = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inform the user name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(153, 13);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(127, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 51);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inform the deepness of this process (Caution: Try to work between 1 to 5)";
            // 
            // txtDeepNess
            // 
            this.txtDeepNess.Location = new System.Drawing.Point(153, 68);
            this.txtDeepNess.Name = "txtDeepNess";
            this.txtDeepNess.Size = new System.Drawing.Size(127, 20);
            this.txtDeepNess.TabIndex = 3;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(16, 321);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rules:";
            // 
            // chkExtractHalfList
            // 
            this.chkExtractHalfList.Location = new System.Drawing.Point(19, 147);
            this.chkExtractHalfList.Name = "chkExtractHalfList";
            this.chkExtractHalfList.Size = new System.Drawing.Size(250, 49);
            this.chkExtractHalfList.TabIndex = 6;
            this.chkExtractHalfList.Text = "Extract half of the friends/followers, who have minus followers\\friends.";
            this.chkExtractHalfList.UseVisualStyleBackColor = true;
            // 
            // frmProcessUserNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 356);
            this.Controls.Add(this.chkExtractHalfList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtDeepNess);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.Name = "frmProcessUserNetwork";
            this.Text = "Extract user network";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeepNess;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkExtractHalfList;
    }
}