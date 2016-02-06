using AmosBatista.ExtractFollowLike.Context;
using System.Data.SqlServerCe;
using System.Collections.Generic;


namespace AmosBatista.ExtractFollowLike.Data.Repository.Database
{
    public class UserRelationshipRepository
    {
        public void SaveUserFollower(TwitterAPPUser user, TwitterAPPUser followerUser)
        {
            var command = new SqlCeCommand("INSERT INTO TwitterFollowers (id, id_Follower) VALUES (@id, @id_Follower)");
            command.Parameters.Add("id", user.id_str);
            command.Parameters.Add("id_Follower", followerUser.id_str);
            SQLOperation.ExecuteSQLCommand(command);
        }

        public void EraseAllData()
        {
            var command = new SqlCeCommand("DELETE FROM TwitterFollowers");
            SQLOperation.ExecuteSQLCommand(command);
        }
    }
}
