using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepstr_Posts : TwitterRepository, ITwitterExtractorByUser
    {
        // Get all posts of a specific user
        public string GetResponse(TwitterAPPUser user)
        {
            var opt = new UserTimelineOptions();
            opt.ScreenName = user.screen_name;
            opt.IncludeRetweets = true;
            opt.Count = postCount;

            var response = TwitterTimeline.UserTimeline(GenerateAuthentication(), opt);
            return response.Content;
        }

        private int postCount;

        public TwitterRepstr_Posts(int postCountToProcess)
        {
            postCount = postCountToProcess;
        }
    }
}
