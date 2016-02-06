using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using AmosBatista.ExtractFollowLike.Data.Repository.Database;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using System;
namespace AmosBatista.ExtractFollowLike.Application.ContinuosProcess
{
    public class StatusListProcessor : TwitterGenericProcess<SearchResult> 
    {
        /* This function will generate a list of status. As Twitter always cut the processment 
         * in parts, these lists are the part the system will generate.
         * This process will control the process of re-calling the API, keep the records of Max and Min posts, 
         * and the control of time, when an exception by limit of processment occours.
         */

        public List<SearchResult> ExtractResponseList(ITwitterExtractor extractor, RepositoryOptions repOptions)
        {
            var responseList = new List<SearchResult>();

            var apiCallControl = new APICallProperties();
            apiCallControl.MaxId = 0;
            apiCallControl.SinceId = 0;

            int MaxPostPerRequest = extractor.GetMaxResponsePerRequest();

            SearchResult response;


            while (repOptions.RecordCount > 0)
            {

                if (repOptions.RecordCount <= MaxPostPerRequest)
                {
                    apiCallControl.Count = repOptions.RecordCount;
                    repOptions.RecordCount = 0;
                }
                else
                {
                    apiCallControl.Count = MaxPostPerRequest;
                    repOptions.RecordCount = repOptions.RecordCount - MaxPostPerRequest;
                }

                repOptions.apiCallProperties = apiCallControl;

                // Setting the extractor process, and get the result
                response = ExtractResponse(extractor, repOptions);

                apiCallControl.MaxId = response.max_id + 1;
                apiCallControl.SinceId = response.since_id;

                responseList.Add(response);

            }

            return responseList;
        }
    }
}
