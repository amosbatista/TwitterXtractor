using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using System;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepstr_FollowersID : TwitterRepository, ITwitterExtractor
    {
        private int maxRequest = 5000;

        // Read all followers from an specific user. Suposing the twitter api will return a string, that the kind of object it will send
        public string GetResponse(RepositoryOptions options)
        {
            var opt = new UsersIdsOptions();
            opt.UserId = Decimal.Parse(options.twitterUser.id_str);

            if (options.nextCursor == null)
                opt.Cursor = 0;
            else
            {
                if (options.nextCursor == "")
                    opt.Cursor = 0;
                else
                    opt.Cursor = long.Parse(options.nextCursor);
            }

            var response = TwitterFriendship.FollowersIds(GenerateAuthentication(), opt);

            return response.Content;          

        }

        public int GetMaxResponsePerRequest()
        {
            return maxRequest;
        }

    }
}

