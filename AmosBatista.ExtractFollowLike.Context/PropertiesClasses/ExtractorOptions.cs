using AmosBatista.ExtractFollowLike.Context.Interface;

namespace AmosBatista.ExtractFollowLike.Context.PropertiesClasses
{
    public class ExtractorOptions 
    {
        public string Query {get; set; }
        public int RecordCount { get; set; }
        public int ResultsByRequest { get; set; }
        public string ResultType { get; set; }
    }
}
