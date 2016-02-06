namespace AmosBatista.ExtractFollowLike.Context.Interface
{
    public interface ITwitterExtractorByUser : ITwitterExtractor
    {
        string GetResponse(TwitterAPPUser user);
    }
}
