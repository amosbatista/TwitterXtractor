using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Data.Repository.Database;

namespace AmosBatista.ExtractFollowLike.Application
{
    public class TwitterFollowersProcess:TwitterProcess
    {
        // It will extract my user followers
        public void ExtractMyFollowers()
        {
            var extrator = new TwitterRepstr_Followers();
            userList = base.ExtractUsersFrom(extrator);

            // Saving in the database
            var dbReps = new DatabaseRepository();
            TwitterAPPUser newUser;

            foreach (decimal userId in userList.ids)
            {
                newUser = new TwitterAPPUser();
                newUser.id_str = userId.ToString();
                newUser.screen_name = "";

                dbReps.SaveUserFollower(MyUser, newUser);
            }
        }
    }
}
