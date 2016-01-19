using AmosBatista.Utilities;
using Twitterizer;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public abstract class TwitterRepository
    {
        // All keys of the app
        private struct TwitterAppData
        {
            static public string app_consumer_key = "gnkAYQUwKweejm9zVggHxUSvc";
            static public string app_token = "72423411-N03863aYbYBhHBORZLz7SzLh7u0mO0PXwD6riY9Bi";
            static public string app_consumerSecret = "CtnUaebdziWbxh8mEqU9CoCR8LFJxYJAazsPXwBM6PGPkkzZzt";
            static public string app_TokenSecret = "n64frsK0JEEETwKSRfdVLMqfkHOgoDVyrHGPnfC78Niwd";
        }

        // Class that will return the authentication
        protected OAuthTokens GenerateAuthentication()
        {
            var newAuth = new OAuthTokens();

            newAuth.ConsumerKey = TwitterAppData.app_consumer_key;
            newAuth.ConsumerSecret = TwitterAppData.app_consumerSecret;
            newAuth.AccessToken = TwitterAppData.app_token;
            newAuth.AccessTokenSecret = TwitterAppData.app_TokenSecret;

            return newAuth;
        }
    }
}
