using AmosBatista.ExtractFollowLike.Application;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using System.Threading;
using System;

namespace AmosBatista.ExtractFollowLike.Application.ContactNet
{
    public class FriendsIdList : TwitterGenericProcess<UserIdList>
    {
        public UserIdList GetFriends(RepositoryOptions options)
        {
            var extractor = new TwitterRepstr_FriendsID();
            var userList = new UserIdList();
            var resultList = new UserIdList();
            string cursor = "";

            while (cursor != "0")
            {
                try
                {
                    resultList = ExtractResponse(extractor, options);
                    //Thread.Sleep(60000); // One minute
                    options.nextCursor = resultList.next_cursor_str;
                    cursor = resultList.next_cursor_str;
                    userList.ids.AddRange(resultList.ids);
                }
                catch (Exception e)
                {
                    if (e.Message == "Rate limit exceeded")
                        Thread.Sleep(800000); // 15 minutes pause
                    else
                        throw e;
                }
            }
            
            return userList;
        }
    }
}
