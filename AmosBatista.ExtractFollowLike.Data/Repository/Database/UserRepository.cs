using AmosBatista.ExtractFollowLike.Context;
using System.Data.SqlServerCe;
using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Database
{
    public class UserRepository
    {

        public void SaveNewUser(TwitterAPPUser user)
        {

            var command = new SqlCeCommand("INSERT INTO TwitterUser (id, screen_name, followersCount, friendsCount) VALUES (@id, @screen_name, @followersCount, @friendsCount)");
            command.Parameters.Add("id", user.id_str);
            command.Parameters.Add("screen_name", user.screen_name);
            command.Parameters.Add("followersCount", user.followers_count);
            command.Parameters.Add("friendsCount", user.friends_count);
            SQLOperation.ExecuteSQLCommand(command);
        }

        public TwitterAPPUser LoadUser(string userId)
        {
            TwitterAPPUser twitterUser = null;

            var command = new SqlCeCommand("SELECT screen_name, followersCount, friendsCount FROM TwitterUser WHERE id = @id");
            command.Parameters.Add("id", userId);

            var dr = SQLOperation.ExecuteSQLCommandWithResult(command);

            if (dr.Read())
            {
                twitterUser = new TwitterAPPUser();
                twitterUser.id_str = userId;
                twitterUser.screen_name = dr.GetString(0);
                twitterUser.followers_count = dr.GetInt32(1);
                twitterUser.followers_count = dr.GetInt32(2);
            }
            dr.Close();

            return twitterUser;

        }

        public TwitterAPPUser LoadUserByScreenName(string screenName)
        {
            TwitterAPPUser twitterUser = null;

            var command = new SqlCeCommand("SELECT id, followersCount, friendsCount FROM TwitterUser WHERE screen_name = @screen_name");
            command.Parameters.Add("screen_name", screenName);

            var dr = SQLOperation.ExecuteSQLCommandWithResult(command);

            if (dr.Read())
            {
                twitterUser = new TwitterAPPUser();
                twitterUser.screen_name = screenName;
                twitterUser.id_str = dr.GetString(0);
                twitterUser.followers_count = dr.GetInt32(1);
                twitterUser.followers_count = dr.GetInt32(2);
            }
            dr.Close();

            return twitterUser;

        }

        public void EraseAllData()
        {
            var command = new SqlCeCommand("DELETE FROM TwitterUser");
            SQLOperation.ExecuteSQLCommand(command);
        }
    }
}
