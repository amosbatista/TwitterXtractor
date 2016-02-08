using MySql.Data.MySqlClient;
using AmosBatista.ExtractFollowLike.Data.Properties;

namespace AmosBatista.ExtractFollowLike.Data.Repository.MySQLDatabase
{
    public class DBRepository
    {
        protected static MySqlConnection GenerateConnection()
        {

            // Getting connection 
            string sqlConnectionString = Settings.Default.MySQLDBConn;

            // Setting connection
            MySqlConnection sqlConnection = new MySqlConnection(sqlConnectionString);

            return sqlConnection;
        }

        protected static void ExecuteSQLCommand(MySqlCommand sqlCommand)
        {
            //Setting command connection
            sqlCommand.Connection = GenerateConnection();

            //Execute command
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }


    }
}
