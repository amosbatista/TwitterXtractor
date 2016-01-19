using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    // Class used to deserialize the response of Twitter response
    public class UserList
    {
        public List<decimal> ids;

        public UserList()
        {
            ids = new List<decimal>();
        }
    }
}
