using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Data.Repository.Database;
using System.Collections.Generic;
using System;

namespace AmosBatista.ExtractFollowLike.Application
{
    public class ExtractRT_ByFrom_User : TwitterGenericProcess<List<StatusInfo>> 
    {
        private List<StatusInfo> postListFromMainUser;
        private TwitterAPPUser mainUser;

        public ExtractRT_ByFrom_User(string userName)
        {
            mainUser = new TwitterAPPUser();
            mainUser.screen_name = userName;
        }

        private List<StatusInfo> LoadStatusOfUser()
        {
            var extrator = new TwitterRepstr_Posts(50);
            var user = new TwitterAPPUser();
            user = mainUser;

            var content = base.ExtractResponse(extrator, user);
            return content;
        }

        // Main flow of this process
        public void ToProcess()
        {
            var RT_DB_Repository = new RT_Repository();

            // Create the list of posts
            postListFromMainUser = LoadStatusOfUser();

            // Listing all content
            foreach (StatusInfo status in postListFromMainUser)
            {

                // Watch if the post have RTs or, at same time, if it were an RT
                var RTPosts = new List<RTStatusInfo>();

                if (status.retweeted_status != null)
                {
                    // Extract all RTs from the post
                    RTPosts = GetRetwittedStatus(status.retweeted_status.id_str);
                }
                else
                {
                    if (status.retweet_count > 0)
                    {
                        // Extract all RTs from the post
                        RTPosts = GetRetwittedStatus(status.id_str);
                    }
                }

                // Saving all information to the database
                foreach (RTStatusInfo rsPost in RTPosts)
                {
                    /* When saving, consider
                     * The users of post and RT. Not important the order
                     * The id of orign post
                     * The content of the original post
                     */
                    RT_DB_Repository.SaveNewRT(rsPost.retweeted_status.user.screen_name, rsPost.user.screen_name, status.id_str, rsPost.text, rsPost.retweeted_status.user.id_str,rsPost.user.id_str);
                }                
            }

        }


        private List<RTStatusInfo> GetRetwittedStatus(string postId)
        {
            var RTApplication = new GetStatusRetwiiters();
            return RTApplication.GetContent(postId);
        }

    }
}
