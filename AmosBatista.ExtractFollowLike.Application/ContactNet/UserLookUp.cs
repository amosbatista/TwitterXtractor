using AmosBatista.ExtractFollowLike.Application;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using System.Threading;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context;
using System;

namespace AmosBatista.ExtractFollowLike.Application.ContactNet
{
    public class UserLookUp : TwitterGenericProcess<List<TwitterAPPUser>>
    {
        public List<TwitterAPPUser> GetUserCompleteList(RepositoryOptions options)
        {
            var extractor = new TwitterRpstr_UsersLookUp();
            var userList = new List<TwitterAPPUser>();

            var completeIdList = new List<decimal>();
            completeIdList = options.userList.ids;

            // Loop to process all the ids
            while (completeIdList.Count > 0)
            {
                options.userList.ids = completeIdList.GetRange(0, GetArrayLimit(extractor.GetMaxResponsePerRequest(), completeIdList));
                completeIdList.RemoveRange(0, GetArrayLimit(extractor.GetMaxResponsePerRequest(), options.userList.ids));

                try
                {
                    userList.AddRange(ExtractResponse(extractor, options));
                    Thread.Sleep(15000); // One minute
                }
                catch (Exception e)
                {
                    if (e.Message == "Rate limit exceeded")
                        Thread.Sleep(800000); // 10 minutes pause
                    else
                        throw e;
                }
            }
            return userList;
        }

        private int GetArrayLimit(int maxOfExtrator, List<decimal> array)
        {
            if ( array.Count <= maxOfExtrator)
                return array.Count;
            else
                return maxOfExtrator;
        }
    }
}
