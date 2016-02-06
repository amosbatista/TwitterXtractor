using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using System;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepstr_FriendsID : TwitterRepository, ITwitterExtractor
    {
        private int maxRequest = 3000;

        // Get all user that a specific user follows
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

            var response = TwitterFriendship.FriendsIds(GenerateAuthentication(),opt);

            return response.Content;
        }

        public int GetMaxResponsePerRequest()
        {
            return maxRequest;
        }
    }
}
