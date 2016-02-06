using AmosBatista.ExtractFollowLike.Context.PropertiesClasses;

namespace AmosBatista.ExtractFollowLike.Context.Interface
{
    public interface ITwitterExtractor
    {
        string GetResponse(RepositoryOptions options);
        int GetMaxResponsePerRequest();
    }
}
