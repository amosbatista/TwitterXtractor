
namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    public class RelationshipStatus_Structure
    {
        public RelationshipStatus target {get;set;}
        public RelationshipStatus source { get; set; }

        public RelationshipStatus_Structure()
        {
            target = new RelationshipStatus();
            source = new RelationshipStatus();
        }
    }

}
