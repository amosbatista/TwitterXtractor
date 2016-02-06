using AmosBatista.ExtractFollowLike.Application;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using System.Threading;
using System;

namespace AmosBatista.ExtractFollowLike.Application.ContactNet
{
    public class FollowerIdList : TwitterGenericProcess<UserIdList>
    {
        public UserIdList GetFollowers(RepositoryOptions options)
        { 
            var extractor = new TwitterRepstr_FollowersID();
            var userList = new UserIdList();
            var resultList = new UserIdList();
            string cursor = "";

            while (cursor != "0")
            {
                try
                {
                    resultList = ExtractResponse(extractor, options);
                    options.nextCursor = resultList.next_cursor_str;
                    cursor = resultList.next_cursor_str;
                    userList.ids.AddRange(resultList.ids);
                }
                catch (Exception e)
                {
                    if (e.Message == "Rate limit exceeded")
                        Thread.Sleep(901000); // 10 minutes pause
                    else
                        throw e;
                }
                
            }

            return userList;
        }
    }
}

