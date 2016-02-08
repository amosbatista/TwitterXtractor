
namespace AmosBatista.ExtractFollowLike.Context.PropertiesClasses
{
    public class NetWorkStatisticsProperties
    {
        public string twitterName;
        public string deepnessCount;
        public bool extractHalfMinorsUsers;
        public bool generateNewStatistic;

        public NetWorkStatisticsProperties()
        {
            twitterName = "";
            deepnessCount = "1";
            extractHalfMinorsUsers = true;
            generateNewStatistic = false;
        }
    }


}
