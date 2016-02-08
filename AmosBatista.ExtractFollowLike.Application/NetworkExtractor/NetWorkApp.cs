using AmosBatista.ExtractFollowLike.Application.ContactNet;

using AmosBatista.ExtractFollowLike.Data.Repository.MySQLDatabase;
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

            // Main list
            var processedUserList = new TwitterUserList(); // Used in the interaction

            // Arrays of friends and followers
            var friendsReps = new FriendsIdList();
            var followersReps = new FollowerIdList();
            var userLookUp = new UserLookUp();
            var relationshipReps = new GetRelationshipStatus();

            var followersList = new List<TwitterAPPUser>();
            var followersIdList = new UserIdList();
            var friendsList = new List<TwitterAPPUser>();
            var friendsIdList = new UserIdList();

            var opt = new RepositoryOptions();

            var newFollowersUser = new TwitterAPPUser();
            var newFriendUser = new TwitterAPPUser();
            var newUserToSave = new TwitterAPPUser();

            // Lists of FR and FF from each user
            var actualUserFriendIdList = new UserIdList();
            var actualUserFollowerIdList = new UserIdList();
            var idListToProcess = new UserIdList();
            var userListToProcess = new List<TwitterAPPUser>();

            var relationshipStatus = new RelationshipStatus_FinalResult();

            // Determine the kind of process
            if (searchProp.generateNewStatistic == true)
            {
                userDB.EraseAllData();
                followerDB.EraseAllData();

                // Setting the user for the first time
                opt.twitterUser.screen_name = searchProp.twitterName;

                // Loading me as the first user
                var twitterUserRep = new LoadUser();
                var mainUser = twitterUserRep.GetUser(opt);

                // Save the user
                userDB.SaveNewUser(mainUser);
                userDB.SetUserAsProcessed(mainUser); // To impeding the first user to be processed again

                // Generation of FR (friends) and FF (followers) list
                opt.twitterUser.id_str = mainUser.id_str;

                // Getting the friends and followers list
                followersIdList = followersReps.GetFollowers(opt);
                friendsIdList = friendsReps.GetFriends(opt);

                opt.userList = followersIdList;
                followersList = userLookUp.GetUserCompleteList(opt);

                opt.userList = friendsIdList;
                friendsList = userLookUp.GetUserCompleteList(opt);


                // Reading all followers list
                foreach (TwitterAPPUser user in followersList)
                {
                    // Save the current user
                    userDB.SaveNewUser(user);

                    // Save the relationship
                    followerDB.SaveUserFollower(mainUser, user);
                }

                // Reading all friends list
                foreach (TwitterAPPUser user in friendsList)
                {
                    // Save the current user
                    userDB.SaveNewUser(user);

                    // Save the relationship
                    followerDB.SaveUserFollower(user, mainUser);
                }

                // Combinning the 2 list
                userListToProcess.AddRange(friendsList);
                userListToProcess.AddRange(followersList);
            }
            else
            {
                // Load the list of the users
                userListToProcess = userDB.LoadUnprocessedUsers();
            }

            // Reading all this list, to get each contacts
            foreach (TwitterAPPUser userSource in userListToProcess)
            {

                foreach (TwitterAPPUser userTarget in userListToProcess)
                {
                    opt.twitterUser = userSource;
                    opt.twitterUser_Target = userTarget;

                    relationshipStatus = relationshipReps.Get(opt);

                    // Saving the user relationship, by the result response
                    if (relationshipStatus.relationship.target.following == true)
                        followerDB.SaveUserFollower(userSource, userTarget);
                    if (relationshipStatus.relationship.target.followed_by == true)
                        followerDB.SaveUserFollower(userTarget, userSource);
                }

                // After all, indicate the user was processed
                userDB.SetUserAsProcessed(userSource);
            }
        }

        private void ExtractFollowersAndFriendsFromUser(string userId, UserIdList contactList)
        {
            var opt = new RepositoryOptions();
            var friendsReps = new FriendsIdList();
            var followersReps = new FollowerIdList();

            var mainUser = new TwitterAPPUser();
            mainUser.id_str = userId;

            var newUserToSave = new TwitterAPPUser();

            var userDB = new UserRepository();
            var followerDB = new UserRelationshipRepository();


            // Get the friend list of this user
            opt.twitterUser.id_str = mainUser.id_str;
            var actualUserFriendIdList = friendsReps.GetFriends(opt);

            // Select a list of these friends that are in the friends/followers list of the user
            var idListToProcess = new UserIdList();
            idListToProcess.ids.AddRange(from actualUserId in actualUserFriendIdList.ids where contactList.ids.Contains(actualUserId) select actualUserId);

            // List all this users ids
            foreach (decimal actualUserId in idListToProcess.ids)
            {
                // Save the relationship of this user
                newUserToSave = new TwitterAPPUser();
                newUserToSave.id_str = actualUserId.ToString();
                followerDB.SaveUserFollower(newUserToSave, mainUser);
            }

            // Get the follower list of this user
            idListToProcess.ids.Clear();
            opt.twitterUser.id_str = mainUser.id_str;
            var actualUserFollowerIdList = followersReps.GetFollowers(opt);

            // Select a list of these followers that are in the friends/followers list of the user
            idListToProcess.ids.AddRange(from actualUserId in actualUserFollowerIdList.ids where contactList.ids.Contains(actualUserId) select actualUserId);

            // List all this users ids
            foreach (decimal actualUserId in idListToProcess.ids)
            {
                // Save the relationship of this user
                newUserToSave = new TwitterAPPUser();
                newUserToSave.id_str = actualUserId.ToString();
                followerDB.SaveUserFollower(mainUser, newUserToSave);
            }

            // After all, indicate the user was processed
            userDB.SetUserAsProcessed(mainUser);
        }
    }
}
