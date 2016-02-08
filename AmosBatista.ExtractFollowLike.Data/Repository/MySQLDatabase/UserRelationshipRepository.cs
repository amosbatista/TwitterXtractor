using AmosBatista.ExtractFollowLike.Context;
using MySql.Data.MySqlClient;
using System.Collections.Generic;


namespace AmosBatista.ExtractFollowLike.Data.Repository.MySQLDatabase
{
    public class UserRelationshipRepository : DBRepository
    {
        public void SaveUserFollower(TwitterAPPUser user, TwitterAPPUser followerUser)
        {
            var command = new MySqlCommand("INSERT INTO TwitterFollowers (id, id_Follower) VALUES (?id, ?id_Follower)");
            command.Parameters.AddWithValue("?id", user.id_str);
            command.Parameters.AddWithValue("?id_Follower", followerUser.id_str);
            command.Connection = GenerateConnection();
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        public void EraseAllData()
        {
            var command = new MySqlCommand("DELETE FROM TwitterFollowers");
            command.Connection = GenerateConnection();
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
    }
}
