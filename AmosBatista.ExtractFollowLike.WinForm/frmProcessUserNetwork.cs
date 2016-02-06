using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AmosBatista.ExtractFollowLike.Application.NetworkExtractor;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;

namespace AmosBatista.ExtractFollowLike.WinForm
{
    public partial class frmProcessUserNetwork : Form
    {
        public frmProcessUserNetwork()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            var searchProps = new NetWorkStatisticsProperties();
            searchProps.twitterName = txtUserName.Text;
            searchProps.deepnessCount = txtDeepNess.Text;
            searchProps.extractHalfMinorsUsers = chkExtractHalfList.Checked;

            var netWorkApp = new NetWorkApp();
            netWorkApp.GenerateNetWorkStatistics(searchProps);
            MessageBox.Show("End of processment");
        }
    }
}
