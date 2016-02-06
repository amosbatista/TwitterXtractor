using AmosBatista.ExtractFollowLike.Context.Interface;
using AmosBatista.ExtractFollowLike.Context;
using AmosBatista.ExtractFollowLike.Data.Repository.Twitterizer;
using Newtonsoft.Json;
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;
using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using System;

namespace AmosBatista.ExtractFollowLike.Application
{
    public abstract class TwitterGenericProcess<T> : TwitterRepository_XAuth where T : class
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
            return ToDeserializate(jsonResponse);
        }

        protected T ExtractResponse(ITwitterExtractorByPost extractor, decimal id)
        {
            var jsonResponse = extractor.GetResponse(id);
            return ToDeserializate(jsonResponse);
        }

        // Generic processor, that receives an option object
        protected T ExtractResponse(ITwitterExtractor extractor, RepositoryOptions options)
        {
            
            var jsonResponse = extractor.GetResponse(options);
            var errorList = ToDeserializateError(jsonResponse);

            if (errorList != null)
            {
                if (errorList.errors != null)
                {
                    if (errorList.errors.Count > 0)
                    {
                        throw new Exception(errorList.errors[0].message);
                    }
                }
            }

            return ToDeserializate(jsonResponse);
        }

        // Function that hold the JSON deserialization process
        protected T ToDeserializate(string jsonContent)
        {
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.None;
            var response = JsonConvert.DeserializeObject<T>(jsonContent, settings);
            return response;
        }

        // Function that hold the JSON deserialization process
        protected ErrorList ToDeserializateError(string jsonContent)
        {
            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.None;
            ErrorList response;
            try
            {
                response = JsonConvert.DeserializeObject<ErrorList>(jsonContent, settings);
            }
            catch (Exception e)
            {
                return null;
            }
            return response;
        }

        // String response
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
