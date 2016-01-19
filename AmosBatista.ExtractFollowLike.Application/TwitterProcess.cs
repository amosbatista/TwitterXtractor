using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Data.Repository.Database;
using Newtonsoft.Json;


namespace AmosBatista.ExtractFollowLike.Application
{
    public abstract class TwitterProcess
    {
        protected TwitterAPPUser MyUser { get; set; }

        protected UserList userList;

        public UserList GetUserList()
        {
            return userList;
        }

        // All keys of the app
        protected struct MyUserData
        {
            public static string TwitterUser = "amosbatista";
            public static string TwitterID = "72423411";
        }

        protected UserList ExtractUsersFrom(ITwitterExtractorByUser extractor)
        {
            // Reading the information from Twitter
            var followerXtractor = new TwitterRepstr_Followers();
            return JsonConvert.DeserializeObject<UserList>(extractor.GetResponse(MyUser));
        }

        protected UserInfo ExtractUserInfo(ITwitterExtractorByUser extractor, TwitterAPPUser user)
        {
            var userInfo = new TwitterRepstr_User();
            var jsonResponse  = extractor.GetResponse(user);
            var response = JsonConvert.DeserializeObject<UserInfo>(jsonResponse);
            return response;
        }

        

        protected TwitterProcess()
        {
            MyUser = new TwitterAPPUser();
            MyUser.id_str = MyUserData.TwitterID;
            MyUser.screen_name = MyUserData.TwitterUser;
        }
    }
}
