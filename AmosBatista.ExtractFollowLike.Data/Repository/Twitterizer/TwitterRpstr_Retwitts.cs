using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRpstr_Retwitts : TwitterRepository, ITwitterExtractorByPost
    {

        // Get all user that a specific user follows
        public string GetResponse(decimal postId)
        {
            var response = TwitterStatus.Retweets(GenerateAuthentication(), postId);
            return response.Content;
        }

    }
}
