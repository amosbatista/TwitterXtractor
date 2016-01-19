using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepstr_Followers : TwitterRepository, ITwitterExtractorByUser
    {
        // Read all followers from an specific user. Suposing the twitter api will return a string, that the kind of object it will send
        public string GetResponse(TwitterAPPUser user)
        {
            var opt = new UsersIdsOptions();
            opt.ScreenName = user.screen_name;
            var response = TwitterFriendship.FollowersIds(GenerateAuthentication(), opt);

            return response.Content;          

        }
    }
}
