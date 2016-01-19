using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using Newtonsoft.Json;

namespace AmosBatista.ExtractFollowLike.Application
{
    public abstract class TwitterGenericProcess <T> :TwitterProcess where T:class
    {
        // Object that will keep the information of the response content
        protected T responseObject;

        public T ReturnResponse()
        {
            return responseObject;
        }

        // Generic response
        protected T ExtractResponse(ITwitterExtractorByUser extractor, TwitterAPPUser user)
        {
            var jsonResponse = extractor.GetResponse(user);
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.None;
            var response = JsonConvert.DeserializeObject<T>(jsonResponse, settings);
            responseObject = response;
            return response;
        }

        protected T ExtractResponse(ITwitterExtractorByPost extractor, decimal id)
        {
            var jsonResponse = extractor.GetResponse(id);
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.None;
            var response = JsonConvert.DeserializeObject<T>(jsonResponse, settings);
            responseObject = response;
            return response;
        }

        // Generic response
        protected string ExtractAllContent(ITwitterExtractorByUser extractor, TwitterAPPUser user)
        {
            var jsonResponse = extractor.GetResponse(user);
            return jsonResponse;
        }

        protected string ExtractAllContent(ITwitterExtractorByPost extractor, decimal id)
        {
            var jsonResponse = extractor.GetResponse(id);
            return jsonResponse;
        }
    }
}
