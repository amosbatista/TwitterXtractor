namespace AmosBatista.ExtractFollowLike.Context.Interface
{
    public interface ITwitterExtractorByPost : ITwitterExtractor
    {
        string GetResponse(decimal postId);
    }
}
