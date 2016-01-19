using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using System.Data.SqlServerCe;


namespace AmosBatista.ExtractFollowLike.Data.Repository.Database
{
    public class RT_Repository
    {
        public void SaveNewRT(string TwitterUserName1, string TwitterUserName2, string TwitterId, string TwitterContent, string TwitterUserId_1, string TwitterUserId_2)
        {
            var command = new SqlCeCommand();

            // Setting the saving order
            if (RTStatusExist_PrimeOrder(TwitterUserId_1, TwitterUserId_2))
            {
                command = new SqlCeCommand("INSERT INTO TWITTERS_RT (TwitterUserName_1, TwitterUserName_2, TwitterID, TwitterContent, TwitterUserId_1, TwitterUserId_2) VALUES (@TwitterUserName_1, @TwitterUserName_2, @TwitterID, @TwitterContent, @TwitterUserId_1, @TwitterUserId_2)");
            }
            else
            {
                if (RTStatusExist_InverseOrder(TwitterUserId_1, TwitterUserId_2))
                {
                    command = new SqlCeCommand("INSERT INTO TWITTERS_RT (TwitterUserName_1, TwitterUserName_2, TwitterID, TwitterContent, TwitterUserId_1, TwitterUserId_2) VALUES (@TwitterUserName_2, @TwitterUserName_1, @TwitterID, @TwitterContent, @TwitterUserId_2, @TwitterUserId_1)");
                }
                else
                {
                    command = new SqlCeCommand("INSERT INTO TWITTERS_RT (TwitterUserName_1, TwitterUserName_2, TwitterID, TwitterContent, TwitterUserId_1, TwitterUserId_2) VALUES (@TwitterUserName_1, @TwitterUserName_2, @TwitterID, @TwitterContent, @TwitterUserId_1, @TwitterUserId_2)");
                }
            }

            command.Parameters.Add("TwitterUserName_1", TwitterUserName1);
            command.Parameters.Add("TwitterUserName_2", TwitterUserName2);
            command.Parameters.Add("TwitterID", TwitterId);
            command.Parameters.Add("TwitterContent", TwitterContent);
            command.Parameters.Add("TwitterUserId_1", TwitterUserId_1);
            command.Parameters.Add("TwitterUserId_2", TwitterUserId_2);
            
            SQLOperation.ExecuteSQLCommand(command);
        }

        public bool RTStatusExist_PrimeOrder(string TwitterUserId_1, string TwitterUserId_2)
        {
            var command = new SqlCeCommand("SELECT 1 FROM TWITTERS_RT WHERE (TwitterUserId_1 = @TwitterUserId_1 AND TwitterUserId_2 = @TwitterUserId_2)");
            command.Parameters.Add("TwitterUserId_1", TwitterUserId_1);
            command.Parameters.Add("TwitterUserId_2", TwitterUserId_2);

            var dr = SQLOperation.ExecuteSQLCommandWithResult(command);

            if (dr.Read() == true)
            {
                dr.Close();
                return true;
            }
            dr.Close();
            return false;
        }

        public bool RTStatusExist_InverseOrder(string TwitterUserId_1, string TwitterUserId_2)
        {
            var command = new SqlCeCommand("SELECT 1 FROM TWITTERS_RT WHERE (TwitterUserId_2 = @TwitterUserId_1 AND TwitterUserId_1 = @TwitterUserId_2)");
            command.Parameters.Add("TwitterUserId_1", TwitterUserId_1);
            command.Parameters.Add("TwitterUserId_2", TwitterUserId_2);

            var dr = SQLOperation.ExecuteSQLCommandWithResult(command);

            if (dr.Read() == true)
            {
                dr.Close();
                return true;
            }
            dr.Close();
            return false;
        }
    }
}
