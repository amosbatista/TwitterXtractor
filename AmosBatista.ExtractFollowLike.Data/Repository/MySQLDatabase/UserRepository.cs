using AmosBatista.ExtractFollowLike.Context;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Data.Repository.MySQLDatabase
{
    public class UserRepository : DBRepository
    {

        public void SaveNewUser(TwitterAPPUser user)
        {

            var conn = GenerateConnection();
            conn.Open();

            var command = conn.CreateCommand();
            command.CommandText = "INSERT INTO TwitterUser (id, screen_name, followersCount, friendsCount, userProcessed) VALUES (?id, ?screen_name, ?followersCount, ?friendsCount, 0)";
            command.Parameters.AddWithValue("?id", user.id_str);
            command.Parameters.AddWithValue("?screen_name", user.screen_name);
            command.Parameters.AddWithValue("?followersCount", user.followers_count);
            command.Parameters.AddWithValue("?friendsCount", user.friends_count);


            command.ExecuteNonQuery();
            conn.Close();
        }

        public TwitterAPPUser LoadUser(string userId)
        {
            TwitterAPPUser twitterUser = null;

            var command = new MySqlCommand("SELECT screen_name, followersCount, friendsCount, userProcessed FROM TwitterUser WHERE id = ?id");
            command.Parameters.AddWithValue("?id", userId);

            command.Connection = GenerateConnection();
            command.Connection.Open();
            
            var dr = command.ExecuteReader();

            if (dr.Read())
            {
                twitterUser = new TwitterAPPUser();
                twitterUser.id_str = userId;
                twitterUser.screen_name = dr.GetString(0);
                twitterUser.followers_count = dr.GetInt32(1);
                twitterUser.friends_count = dr.GetInt32(2);
                twitterUser.userProcessed = dr.GetBoolean(3);
            }
            dr.Close();
            
            command.Connection.Close();

            return twitterUser;

        }

        public TwitterAPPUser LoadUserByScreenName(string screenName)
        {
            TwitterAPPUser twitterUser = null;

            var command = new MySqlCommand("SELECT id, followersCount, friendsCount, userProcessed FROM TwitterUser WHERE screen_name = ?screen_name");
            command.Parameters.AddWithValue("?screen_name", screenName);

            command.Connection = GenerateConnection();
            command.Connection.Open();
            var dr = command.ExecuteReader();

            if (dr.Read())
            {
                twitterUser = new TwitterAPPUser();
                twitterUser.screen_name = screenName;
                twitterUser.id_str = dr.GetString(0);
                twitterUser.followers_count = dr.GetInt32(1);
                twitterUser.friends_count = dr.GetInt32(2);
                twitterUser.userProcessed = dr.GetBoolean(3);
            }
            dr.Close();
            command.Connection.Close();
            return twitterUser;

        }

        public void EraseAllData()
        {
            var command = new MySqlCommand("DELETE FROM TwitterUser");
            command.Connection = GenerateConnection();
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public List<decimal> LoadUnprocessedUsersID()
        {
            var userIdList = new List<decimal>();

            var command = new MySqlCommand("SELECT id FROM TwitterUser WHERE userProcessed = 0");
            
            command.Connection = GenerateConnection();
            command.Connection.Open();
            var dr = command.ExecuteReader();

            while (dr.Read())
            {
                userIdList.Add(decimal.Parse(dr.GetString(0)));
            }
            dr.Close();
            command.Connection.Close();
            return userIdList;
        }

        public List<TwitterAPPUser> LoadUnprocessedUsers()
        {
            var userList = new List<TwitterAPPUser>();
            TwitterAPPUser newUser;

            var command = new MySqlCommand("SELECT id, screen_name, followersCount, friendsCount, userProcessed FROM TwitterUser WHERE userProcessed = 0");

            command.Connection = GenerateConnection();
            command.Connection.Open();
            var dr = command.ExecuteReader();

            while (dr.Read())
            {
                newUser = new TwitterAPPUser();
                newUser.id_str = dr.GetString(0);
                newUser.screen_name = dr.GetString(1);
                newUser.followers_count = dr.GetInt32(2);
                newUser.friends_count = dr.GetInt32(3);
                newUser.userProcessed = dr.GetBoolean(4);

                userList.Add(newUser);
            }
            dr.Close();
            command.Connection.Close();
            return userList;
        }

        public void SetUserAsProcessed(TwitterAPPUser user)
        {

            var command = new MySqlCommand("UPDATE TwitterUser SET userProcessed = 1 WHERE ID = ?id");
            command.Parameters.AddWithValue("?id", user.id_str);
            
            command.Connection = GenerateConnection();
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
