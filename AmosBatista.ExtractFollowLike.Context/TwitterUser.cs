namespace AmosBatista.ExtractFollowLike.Context
{
    public class TwitterAPPUser
    {
        public string  id_str { get; set; }
        public string screen_name { get; set; }
        public int followers_count { get; set; }
        public int friends_count { get; set; }
        
        // System variable
        public bool userProcessed { get; set; }
    }
}
