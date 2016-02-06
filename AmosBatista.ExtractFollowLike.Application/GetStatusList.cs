using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using System.Text;
using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Application
{
    public class GetStatusList : TwitterGenericProcess<List<StatusInfo>> 
    {
        

        /*public List<StatusInfo> GetList(string userName)
        {
            var extrator = new TwitterRepstr_Posts(5);
            var user = new TwitterAPPUser();
            user.screen_name = userName;

            var content = base.ExtractResponse(extrator, user);
            return content;
        }

        public string GetAllResponse (string userName)
        {
            var extrator = new TwitterRepstr_Posts(5);
            var user = new TwitterAPPUser();
            user.screen_name = userName;

            var content = base.ExtractAllContent(extrator, user);
            return content;
        }*/
    }
}
