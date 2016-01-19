using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using System;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepstr_User :  TwitterRepository, ITwitterExtractorByUser
    {
        // Read all followers from an specific user. Suposing the twitter api will return a string, that the kind of object it will send
        public string GetResponse(TwitterAPPUser user)
        {
            var response = TwitterUser.Show(GenerateAuthentication(), Decimal.Parse(user.id_str));
            return response.Content;
        }
    }
}
