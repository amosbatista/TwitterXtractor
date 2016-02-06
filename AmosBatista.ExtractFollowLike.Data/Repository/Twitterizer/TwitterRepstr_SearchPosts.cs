using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using Twitterizer;
using System.Collections.Generic;
using AmosBatista.ExtractFollowLike.Context.Interface;
using System;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer
{
    public class TwitterRepstr_SearchPosts : TwitterRepository, ITwitterExtractor, ITwitterExtractorBySearch
    {
        private int maxRequest = 100;
        private decimal maxId;
        private decimal sinceId;

        public string GetResponse(RepositoryOptions options)
        {
            var opt = new SearchOptions();
            opt.MaxId = maxRequest;
            opt.SinceId = sinceId;

            opt.Count = options.apiCallProperties.Count;

            var response = TwitterSearch.Search(GenerateAuthentication(), options.Query, opt);
            return response.Content;
        }

        public int GetMaxResponsePerRequest()
        {
            return maxRequest;
        }

        public void SetMaxId(decimal value)
        {
            maxId = value;
        }

        public void SetSinceId(decimal value)
        {
            sinceId = value;
        }
    }
}
