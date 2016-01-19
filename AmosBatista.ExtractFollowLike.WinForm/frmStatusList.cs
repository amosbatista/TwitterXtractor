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
    public partial class frmStatusList : Form
    {
        public frmStatusList()
        {
            InitializeComponent();
        }

        private void btnGenerateList_Click(object sender, EventArgs e)
        {
            var appTwitter = new GetStatusList();
            var timeLine = appTwitter.GetAllResponse(txtScreenName.Text);
            txtResult.Text = timeLine;
            /*txtResult.AppendText("There's " + timeLine.Count.ToString() + " posts. Bellow, the content:");

            foreach (StatusInfo statusinfo in timeLine)
            {
                txtResult.AppendText("ID: " + statusinfo.id.ToString() + " Text: " + statusinfo.text);
                txtResult.AppendText("");

                if (statusinfo.retweeted_status != null)
                {
                    txtResult.AppendText("\n");
                    txtResult.AppendText("RT User:" + statusinfo.retweeted_status.user.screen_name);
                }
            }
             * */
        }

        private void btnGenerateRT_Click(object sender, EventArgs e)
        {
            var appTwitter = new GetStatusRetwiiters();
            txtRTResult.Text = appTwitter.GetStringContent(txtPostId.Text);
        }
    }
}
