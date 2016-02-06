using AmosBatista.ExtractFollowLike.Application;
using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;

namespace AmosBatista.ExtractFollowLike.Application.ContactNet
{
    public class LoadUser : TwitterGenericProcess<TwitterAPPUser>
    {
        public TwitterAPPUser GetUser(RepositoryOptions options)
        {
            var extractor = new TwitterRepstr_User();
            return ExtractResponse(extractor, options);
        }
    }
}


