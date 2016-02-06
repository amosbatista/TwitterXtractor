using AmosBatista.ExtractFollowLike.Context.Interface;

namespace AmosBatista.ExtractFollowLike.Context.PropertiesClasses
{
    public class APICallProperties
    {
        public decimal MaxId { get; set; }
        public decimal SinceId { get; set; }
        public int Count { get; set; }
        public string ResultType { get; set; }
    }
}
