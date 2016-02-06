using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using System.Collections.Generic;


namespace AmosBatista.ExtractFollowLike.Context.PropertiesClasses
{
    public class RepositoryOptions
    {
        public string Query { get; set; }
        public int RecordCount { get; set; }
        //public int ResultsByRequest { get; set; }
        public string ResultType { get; set; }

        public TwitterAPPUser twitterUser { get; set; }
        public APICallProperties apiCallProperties { get; set; }

        public decimal PostId { get; set; }

        public string nextCursor { get; set; }

        public UserIdList userList;

        public RepositoryOptions()
        {
            twitterUser = new TwitterAPPUser();
            apiCallProperties = new APICallProperties();
            userList = new UserIdList();
            nextCursor = "";
        }
    }
}
