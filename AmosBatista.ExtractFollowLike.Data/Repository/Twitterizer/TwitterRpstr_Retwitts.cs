using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRpstr_Retwitts : TwitterRepository, ITwitterExtractor
    {
        public int maxRequest = 100;

        // Get all user that a specific user follows
        public string GetResponse(RepositoryOptions options)
        {
            var response = TwitterStatus.Retweets(GenerateAuthentication(), options.PostId);
            return response.Content;
        }

        public int GetMaxResponsePerRequest()
        {
            return maxRequest;
        }

    }
}
