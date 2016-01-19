namespace AmosBatista.ExtractFollowLike.Context.Interface
{
    public interface ITwitterExtractorByUser
    {
        string GetResponse(TwitterAPPUser user);
    }
}
