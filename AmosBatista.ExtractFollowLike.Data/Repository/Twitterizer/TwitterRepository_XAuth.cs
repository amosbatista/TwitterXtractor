using Twitterizer;
namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public abstract class TwitterRepository_XAuth  : TwitterRepository
    {
        // All keys of the app
        private struct TwitterUserData
        {
            static public string twitterUser = "amosbatista";
            static public string twitterPassword = "iunarihs45@";
        }

        protected OAuthTokens GenerateXAuthAuthentication()
        {
            var newAuth = new OAuthTokens();

            newAuth.ConsumerKey = TwitterAppData.app_consumer_key;
            newAuth.ConsumerSecret = TwitterAppData.app_consumerSecret;

            var accessToken = XAuthUtility.GetAccessTokens(TwitterAppData.app_consumer_key, TwitterAppData.app_consumerSecret, TwitterUserData.twitterUser, TwitterUserData.twitterPassword);

            newAuth.AccessToken = accessToken.Token;
            newAuth.AccessTokenSecret = accessToken.Token;

            return newAuth;
        }
    }
}
