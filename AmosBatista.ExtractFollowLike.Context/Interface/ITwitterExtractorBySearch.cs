
using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;

namespace AmosBatista.ExtractFollowLike.Context.Interface
{
    public interface ITwitterExtractorBySearch : ITwitterExtractor
    {
        //APICallProperties ApiCallProperties();
        void SetMaxId(decimal value);
        void SetSinceId(decimal value);
    }
}
