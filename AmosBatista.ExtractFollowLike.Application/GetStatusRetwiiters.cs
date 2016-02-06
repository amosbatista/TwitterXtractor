using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using System.Text;
using System.Collections.Generic;
using System;

namespace AmosBatista.ExtractFollowLike.Application
{
    public class GetStatusRetwiiters  : TwitterGenericProcess<List<RTStatusInfo>>
    {
        public string GetStringContent(string postId)
        {
            var extrator = new TwitterRpstr_Retwitts();

            //var content = null;//base.ExtractAllContent(extrator, Decimal.Parse(postId));

            return null;
        }

        public List<RTStatusInfo> GetContent(string postId)
        {
            var extrator = new TwitterRpstr_Retwitts();
            //var content = null; // base.ExtractResponse(extrator, Decimal.Parse(postId));

            return null;
        }
    }
}
