using AmosBatista.ExtractFollowLike.Context;
using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    public class TwitterUserList
    {
        public List<TwitterAPPUser> users;
        public string next_cursor;

        public TwitterUserList()
        {
            users = new List<TwitterAPPUser>();
        }

    }
}
