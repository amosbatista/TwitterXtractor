using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using System;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepstr_User :  TwitterRepository, ITwitterExtractor
    {
        int maxRequest = 100;

        // Read all followers from an specific user. Suposing the twitter api will return a string, that the kind of object it will send
        public string GetResponse(RepositoryOptions options)
        {
            var response = TwitterUser.Show(GenerateAuthentication(), options.twitterUser.screen_name);
            return response.Content;
        }

        public int GetMaxResponsePerRequest()
        {
            return maxRequest;
        }
    }
}
