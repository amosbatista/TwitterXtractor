using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    // It's the same of a Twitter
    public class StatusInfo
    {
        public string text;
        public string id_str;
        public decimal id;
        public RetweetedStatus retweeted_status;
        public decimal retweet_count;
        public UserInfo user;
        
    }
}
