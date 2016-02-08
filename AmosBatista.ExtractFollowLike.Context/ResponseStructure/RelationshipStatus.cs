
namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    public class RelationshipStatus
    {
        public bool following {get;set;}
        public bool followed_by { get; set; }

        public RelationshipStatus()
        {
            following = false;
            followed_by = false;
        }
    }
}
