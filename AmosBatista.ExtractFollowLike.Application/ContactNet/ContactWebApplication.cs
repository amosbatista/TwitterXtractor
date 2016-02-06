using AmosBatista.ExtractFollowLike.Data.Repository.Database;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using System;

namespace AmosBatista.ExtractFollowLike.Application.ContactNet
{
    public class ContactWebApplication
    {
        public void GenerateNetWorkStatistics(string twitterName, string deepnessCount)
        {
            // Cleaning database
            var userDB = new UserRepository();
            var followerDB = new UserRelationshipRepository();

            userDB.EraseAllData();
            followerDB.EraseAllData();

            // Main list
            var userListToProcess = new TwitterUserList();
            var processedUserList = new TwitterUserList(); // Used in the interaction

            // Arrays of friends and followers
            var friendsReps = new FriendsIdList();
            var followersReps = new FollowerIdList();
            var userLookUp = new UserLookUp();

            var followersList = new List<TwitterAPPUser>();
            var followersIdList = new UserIdList();
            var friendsList = new List<TwitterAPPUser>();
            var friendsIdList = new UserIdList();

            var opt = new RepositoryOptions();

            var newFollowersUser = new TwitterAPPUser();
            var newFriendUser = new TwitterAPPUser();

            // Setting the user for the first time
            opt.twitterUser.screen_name = twitterName;

            // Loading me as the first user
            var twitterUserRep = new LoadUser();
            var firstUser = twitterUserRep.GetUser(opt);

            // Setting the first array
            userListToProcess.users.Add(firstUser);
            opt.twitterUser.screen_name = "";

            // Main loop
            for (int processorCount = 0; processorCount < Int16.Parse(deepnessCount); processorCount++)
            {

                foreach (TwitterAPPUser user in userListToProcess.users)
                {
                    // Setting the user for the first time
                    opt.twitterUser.id_str = user.id_str;

                    // Verify if the user is the same of the first
                    if (user.id_str == firstUser.id_str && userListToProcess.users.Count > 1)
                        continue;

                    // Getting the friends and followers list
                    followersIdList = followersReps.GetFollowers(opt);
                    opt.userList.ids = followersIdList.ids;
                    //followersList = userLookUp.GetUserCompleteList(opt);
                    
                    friendsIdList = friendsReps.GetFriends(opt);
                    opt.userList.ids = friendsIdList.ids;
                    //friendsList = userLookUp.GetUserCompleteList(opt);

                    foreach (decimal followerUserId in followersIdList.ids )
                    {
                        newFollowersUser = new TwitterAPPUser();
                        newFollowersUser.id_str = followerUserId.ToString();
                        newFollowersUser.screen_name = "";

                        // Saving the the twitters users
                        //if (userDB.LoadUser(newFollowersUser.id_str) == null)
                        userDB.SaveNewUser(newFollowersUser);

                        followerDB.SaveUserFollower(user, newFollowersUser);

                        // Appending these users to the result
                        processedUserList.users.Add(newFollowersUser);
                    }


                    foreach (decimal friendUserId in friendsIdList.ids)
                    {

                        newFriendUser = new TwitterAPPUser();
                        newFriendUser.id_str = friendUserId.ToString();
                        newFriendUser.screen_name = "";

                        // Saving the the twitters users
                        //if (userDB.LoadUser(newFriendUser.id_str) == null)
                        userDB.SaveNewUser(newFriendUser);

                        followerDB.SaveUserFollower(newFriendUser, user);

                        // Appending these users to the result
                        processedUserList.users.Add(newFriendUser);
                    }

                    
                    processedUserList.users.AddRange(friendsList);
                }

                // Setting the result to the main list
                userListToProcess.users.Clear();
                userListToProcess.users.AddRange(processedUserList.users); 
                processedUserList.users.Clear();
            }
        }
    }
}
