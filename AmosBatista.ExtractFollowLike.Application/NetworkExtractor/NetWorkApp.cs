using AmosBatista.ExtractFollowLike.Application.ContactNet;

using AmosBatista.ExtractFollowLike.Data.Repository.Database;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using System;
using System.Linq;

namespace AmosBatista.ExtractFollowLike.Application.NetworkExtractor
{
    public class NetWorkApp
    {
        public void GenerateNetWorkStatistics(NetWorkStatisticsProperties searchProp)
        {
            // Cleaning database
            var userDB = new UserRepository();
            var followerDB = new UserRelationshipRepository();

            //userDB.EraseAllData();
            //followerDB.EraseAllData();

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
            opt.twitterUser.screen_name = searchProp.twitterName;

            // Loading me as the first user
            var twitterUserRep = new LoadUser();
            var firstUser = twitterUserRep.GetUser(opt);

            // Remotion and top 10 users list
            var usersToRemove = new List<TwitterAPPUser>(); 
            var top10Users = new List<TwitterAPPUser>();

            // Setting the first array
            userListToProcess.users.Add(firstUser);
            opt.twitterUser.screen_name = "";

            // Main loop
            for (int processorCount = 0; processorCount < Int16.Parse(searchProp.deepnessCount); processorCount++)
            {
                top10Users.Clear();
                usersToRemove.Clear();

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
                    followersList.AddRange(userLookUp.GetUserCompleteList(opt)); 

                    friendsIdList = friendsReps.GetFriends(opt);
                    opt.userList.ids = friendsIdList.ids;
                    friendsList.AddRange(userLookUp.GetUserCompleteList(opt));

                    if (searchProp.extractHalfMinorsUsers == true)
                    {
                        // Removing the half of users of each list who have minus friends
                        usersToRemove.AddRange((from follower in followersList orderby follower.followers_count ascending select follower).Take(followersList.Count / 2));
                        usersToRemove.AddRange((from friend in friendsList orderby friend.followers_count ascending select friend).Take(friendsList.Count / 2));
                    
                        foreach  (TwitterAPPUser userToRemove in usersToRemove){
                            followersList.Remove(userToRemove);
                            friendsList.Remove(userToRemove);
                        }

                    }

                    // Saving both list to the database. Only save if the user has been saved
                    foreach (TwitterAPPUser userToSave in followersList)
                    {
                        userDB.SaveNewUser(userToSave);
                        followerDB.SaveUserFollower(userToSave, user);
                    }

                    foreach (TwitterAPPUser userToSave in friendsList)
                    {
                        userDB.SaveNewUser(userToSave);
                        followerDB.SaveUserFollower(user, userToSave);
                    }

                    // After saved the users, remove who have more than 5000 users
                    usersToRemove.Clear();
                    usersToRemove.AddRange(from follower in followersList where follower.followers_count > 5000 || follower.friends_count > 5000 select follower);
                    usersToRemove.AddRange(from friend in friendsList where friend.followers_count > 5000 || friend.friends_count > 5000 select friend);

                    foreach (TwitterAPPUser userToRemove in usersToRemove)
                    {
                        followersList.Remove(userToRemove);
                        friendsList.Remove(userToRemove);
                    }
                }

                // After mounted the list, start the process of find the top 5 of each list
                // In this process, we just consider the amount of followers of each user
                top10Users.AddRange((from follower in followersList orderby follower.followers_count descending select follower).Take(2));
                top10Users.AddRange((from follower in followersList orderby follower.friends_count descending select follower).Take(2));
                top10Users.AddRange((from friend in friendsList orderby friend.followers_count descending select friend).Take(2));
                top10Users.AddRange((from friend in friendsList orderby friend.friends_count descending select friend).Take(2));

                // Finally, set the next list of users to process
                userListToProcess.users.Clear();
                userListToProcess.users.AddRange(top10Users);
            }
        }
    }
}
