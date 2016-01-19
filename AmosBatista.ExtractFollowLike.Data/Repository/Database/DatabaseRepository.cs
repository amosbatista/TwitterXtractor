using AmosBatista.ExtractFollowLike.Context;
using System.Data.SqlServerCe;
using System.Collections.Generic;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Database
{
    public class DatabaseRepository
    {
        public void SaveNewUser(TwitterAPPUser user)
        {
            
            var command = new SqlCeCommand("INSERT INTO USUARIOS_TWITTER (IDTWITTER, USERTWITTER) VALUES (@IDTWITTER, @USERTWITTER)");
            command.Parameters.Add("IDTWITTER", user.id_str);
            command.Parameters.Add("USERTWITTER", user.screen_name);
            SQLOperation.ExecuteSQLCommand(command);
        }

        public TwitterAPPUser LoadUser(string userId)
        {
            TwitterAPPUser twitterUser = null;

            var command = new SqlCeCommand("SELECT USERTWITTER FROM USUARIOS_TWITTER WHERE IDTWITTER = @IDTWITTER");
            command.Parameters.Add("IDTWITTER", userId);
            
            var dr = SQLOperation.ExecuteSQLCommandWithResult(command);

            if (dr.Read())
            {
                twitterUser = new TwitterAPPUser();
                twitterUser.id_str = userId;
                twitterUser.screen_name = dr.GetString(0); 
            }
            dr.Close();

            return twitterUser;

        }

        public List<TwitterAPPUser> LoadAllUnrecognizedUsers()
        {
            List<TwitterAPPUser> userList = null;

            var command = new SqlCeCommand("SELECT IDTWITTER, USERTWITTER FROM USUARIOS_TWITTER WHERE USERTWITTER = 'Not identified'");

            var dr = SQLOperation.ExecuteSQLCommandWithResult(command);
            TwitterAPPUser twitterUser;

            while(dr.Read())
            {
                if (userList == null)
                    userList = new List<TwitterAPPUser>();

                twitterUser = new TwitterAPPUser();
                twitterUser.id_str = dr.GetInt64(0).ToString(); 
                twitterUser.screen_name = dr.GetString(1);
                userList.Add(twitterUser);
            }
            dr.Close();
            return userList;
        }

        public void DeleteAllUnrecognizedUsers()
        {
            var command = new SqlCeCommand("DELETE FROM USUARIOS_TWITTER WHERE USERTWITTER = 'Not identified'");
            SQLOperation.ExecuteSQLCommand(command);
        }

        public void SaveUserFollower(TwitterAPPUser user, TwitterAPPUser followerUser)
        {
            var command = new SqlCeCommand("INSERT INTO SEGUIDORES_TWITTER (IDTWITTER, IDTWITTERSEGUIDOR) VALUES (@IDTWITTER, @IDTWITTERSEGUIDOR)");
            command.Parameters.Add("IDTWITTER", user.id_str);
            command.Parameters.Add("IDTWITTERSEGUIDOR", followerUser.id_str);
            SQLOperation.ExecuteSQLCommand(command);
        }
        
    }
}
