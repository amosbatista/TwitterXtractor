using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmosBatista.ExtractFollowLike.Application;

namespace AmosBatista.ExtractFollowLike.WinForm
{
    public partial class frmTwitterExtraction : Form
    {
        public frmTwitterExtraction()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myFollowers = new TwitterFollowersProcess();
            myFollowers.ExtractMyFollowers();

            var myFriends = new TwitterFriendsProcess();
            myFriends.ExtractMyFriends();

            // Processing all user list
            var userOperation = new TwitterUserInfoProcess();
            userOperation.SaveUserList(myFollowers.GetUserList());
            userOperation.SaveUserList(myFriends.GetUserList());
            MessageBox.Show("End of processment.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var userOperation = new TwitterUserInfoProcess();
            userOperation.UpdateUnrecognizedUsers();
            MessageBox.Show("End of update.");
        }
    }
}
