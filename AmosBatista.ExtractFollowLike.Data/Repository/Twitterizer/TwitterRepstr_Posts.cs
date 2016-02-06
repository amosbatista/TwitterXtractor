using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepstr_Posts : TwitterRepository, ITwitterExtractor
    {
        int maxRequest = 100;
        // Get all posts of a specific user
        public string GetResponse(RepositoryOptions options)
        {
            var opt = new UserTimelineOptions();
            opt.ScreenName = options.twitterUser.screen_name;
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

        public int GetMaxResponsePerRequest()
        {
            return maxRequest;
        }
    }
}
