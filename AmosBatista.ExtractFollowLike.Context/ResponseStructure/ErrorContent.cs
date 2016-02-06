
using System;

namespace AmosBatista.ExtractFollowLike.Context.ResponseStructure
{
    public class ErrorContentException
    {
        public string message;
        public int code ;

        public ErrorContentException()
        {
            
            message = "";
            code = 0;
        }
    }
}
