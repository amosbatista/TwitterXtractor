

namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    public class RelationshipStatus_FinalResult
    {
        public RelationshipStatus_Structure relationship { get; set; }

        public RelationshipStatus_FinalResult()
        {
            relationship = new RelationshipStatus_Structure();
        }
    }
}
