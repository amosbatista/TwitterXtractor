using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepstr_Friends : TwitterRepository, ITwitterExtractorByUser
    {
        // Get all user that a specific user follows
        public string GetResponse(TwitterAPPUser user)
        {
            var opt = new UsersIdsOptions();
            opt.ScreenName = user.screen_name;
            var response = TwitterFriendship.FriendsIds(GenerateAuthentication(), opt);

            return response.Content;
        }
    }
}
