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
    public class GetRelationshipStatus : TwitterGenericProcess<RelationshipStatus_FinalResult>
    {
        public RelationshipStatus_FinalResult Get(RepositoryOptions options)
        {
            var extractor = new TwitterRepst_Relationship();
            RelationshipStatus_FinalResult result = null;

            while(result == null){
                try
                {
                    result = ExtractResponse(extractor, options);
                }
                catch (Exception e)
                {
                    if (e.Message == "Rate limit exceeded")
                    {
                        Thread.Sleep(900100); // 15 minutes pause
                        result = null;
                    }
                    else
                        throw e;
                }
            }

            return result;

        }
    }
}
