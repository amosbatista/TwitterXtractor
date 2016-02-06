using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Data.Repository.Database;
using System;



namespace AmosBatista.ExtractFollowLike.Application
{
    public class TwitterUserInfoProcess : TwitterProcess
    {
        public void SaveUserList(UserIdList userList)
        {
            // Saving in the database
            /*var dbReps = new DatabaseRepository();

            TwitterAPPUser newUser;
            var extrator = new TwitterRepstr_User();
            UserInfo userInfo;

            foreach (decimal userId in userList.ids)
            {
                if (dbReps.LoadUser(userId.ToString()) == null)
                {
                    newUser = new TwitterAPPUser();
                    newUser.id_str = userId.ToString();
                    userInfo = base.ExtractUserInfo(extrator, newUser);

                    if (userInfo.screen_name == null)
                        newUser.screen_name = "Not identified";
                    else
                        newUser.screen_name = userInfo.screen_name;

                    dbReps.SaveNewUser(newUser);
                }
            }*/
        }

        public void UpdateUnrecognizedUsers()
        {
            var dbReps = new DatabaseRepository();
            var userList = dbReps.LoadAllUnrecognizedUsers();
            var userListStructured = new UserIdList();

            foreach (TwitterAPPUser user in userList)
                userListStructured.ids.Add(Decimal.Parse(user.id_str));

            dbReps.DeleteAllUnrecognizedUsers();

            SaveUserList(userListStructured);
            
        }
    }
}
