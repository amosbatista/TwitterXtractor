using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    public class SearchResult
    {
        public List<StatusInfo> statuses;

        // Search metadata
        public decimal max_id;
        public decimal since_id;
    }
}
