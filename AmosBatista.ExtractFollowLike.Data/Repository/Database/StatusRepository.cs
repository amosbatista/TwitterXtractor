using AmosBatista.ExtractFollowLike.Context.ResponseStructure;
using System.Data.SqlServerCe;


namespace AmosBatista.ExtractFollowLike.Data.Repository.Database
{
    public class StatusRepository
    {
        public void SaveStatus(StatusInfo status)
        {
            var command = new SqlCeCommand("INSERT INTO STATUS (text, id_str, retweet_count, id_user_str) VALUES (@text, @id_str, @retweet_count, @id_user_str)");
            command.Parameters.AddWithValue("text",status.text.Replace("\n",""));
            command.Parameters.AddWithValue("id_str", status.id_str);
            command.Parameters.AddWithValue("retweet_count", status.retweet_count.ToString());
            command.Parameters.AddWithValue("id_user_str", status.user.id_str);
            SQLOperation.ExecuteSQLCommand(command);            
        }
    }
}
