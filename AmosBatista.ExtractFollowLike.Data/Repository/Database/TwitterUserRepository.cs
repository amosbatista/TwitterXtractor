using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using System.Data.SqlServerCe;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Database
{
    public class TwitterUserRepository
    {
        public void SaveUser(UserInfo user)
        {
            var command = new SqlCeCommand("INSERT INTO STATUS_USER (screen_name, id_str, followers_count, friends_count) VALUES (@screen_name, @id_str, @followers_count, @friends_count)");
            command.Parameters.AddWithValue("screen_name", user.screen_name);
            command.Parameters.AddWithValue("id_str", user.id_str);
            command.Parameters.AddWithValue("followers_count", user.followers_count);
            command.Parameters.AddWithValue("friends_count", user.friends_count);
            SQLOperation.ExecuteSQLCommand(command);
        }
    }
}
