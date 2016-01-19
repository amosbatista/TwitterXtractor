using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Data.Repository.Database;

namespace AmosBatista.ExtractFollowLike.Application
{
    public class TwitterFriendsProcess:TwitterProcess
    {
        // It will extract user I follow
        public void ExtractMyFriends()
        {
            var extrator = new TwitterRepstr_Friends();
            userList = base.ExtractUsersFrom(extrator);

            // Saving in the database
            var dbReps = new DatabaseRepository();

            TwitterAPPUser newUser;

            foreach (decimal userId in userList.ids)
            {
                newUser = new TwitterAPPUser();
                newUser.id_str = userId.ToString();
                newUser.screen_name = "";
                dbReps.SaveUserFollower(newUser, MyUser);
            }
        }
    }
}
