using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using System;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepst_Relationship : TwitterRepository, ITwitterExtractor
    {
        private int maxRequest = 15;

        public string GetResponse(RepositoryOptions options)
        {
            var response = TwitterFriendship.Show(GenerateAuthentication(), Decimal.Parse(options.twitterUser.id_str), Decimal.Parse(options.twitterUser_Target.id_str));
            return response.Content;   
        }

        public int GetMaxResponsePerRequest()
        {
            return maxRequest;
        }
    }
}
