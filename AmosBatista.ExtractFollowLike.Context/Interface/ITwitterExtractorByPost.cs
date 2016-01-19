namespace AmosBatista.ExtractFollowLike.Context.Interface
{
    public interface ITwitterExtractorByPost
    {
        string GetResponse(decimal postId);
    }
}
