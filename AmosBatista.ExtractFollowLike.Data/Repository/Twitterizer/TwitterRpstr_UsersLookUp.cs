using AmosBatista.ExtractFollowLike.Context;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRpstr_UsersLookUp : TwitterRepository, ITwitterExtractor
    {
        int maxRequest = 100;

        // Read all followers from an specific user. Suposing the twitter api will return a string, that the kind of object it will send
        public string GetResponse(RepositoryOptions options)
        {
            var twitterIDCollection = new TwitterIdCollection(options.userList.ids);

            var opt = new LookupUsersOptions();
            opt.UserIds = twitterIDCollection;

            var response = TwitterUser.Lookup(GenerateAuthentication(), opt);

            return response.Content;

        }

        public int GetMaxResponsePerRequest()
        {
            return maxRequest;
        }

    }
}
