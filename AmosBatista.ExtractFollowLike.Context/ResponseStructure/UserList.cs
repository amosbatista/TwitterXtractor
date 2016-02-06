using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    // Class used to deserialize the response of Twitter response
    public class UserIdList
    {
        public List<decimal> ids;
        public string next_cursor_str;

        public UserIdList()
        {
            ids = new List<decimal>();
        }

    }
}
