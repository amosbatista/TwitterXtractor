using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    public class ErrorList
    {
        public List<ErrorContentException> errors ;
        
        public ErrorList()
        {
            errors = new List<ErrorContentException>();
        }
    }
}
