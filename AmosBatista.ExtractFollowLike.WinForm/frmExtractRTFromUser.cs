using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Application;

namespace AmosBatista.ExtractFollowLike.WinForm
{
    public partial class frmExtractRTFromUser : Form
    {
        public frmExtractRTFromUser()
        {
            InitializeComponent();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            //var extractRTs = new ExtractRT_ByFrom_User(txtTwitterUser.Text);
            //extractRTs.ToProcess();

            MessageBox.Show("Process has been finished.");
        }
    }
}
