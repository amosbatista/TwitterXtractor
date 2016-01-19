using System.Data.SqlServerCe;
using System.Data;
using AmosBatista.ExtractFollowLike.Data.Properties;

namespace AmosBatista.ExtractFollowLike.Data.Repository.Database
{
    public class SQLOperation
    {
        public static SqlCeDataReader ExecuteSQLCommandWithResult(SqlCeCommand sqlCommand)
        {
            //Setting command connection
            sqlCommand.Connection = generateConnection();
            
            // Generation the data reader
            sqlCommand.Connection.Open();
            return sqlCommand.ExecuteReader();
        }

        public static void ExecuteSQLCommand(SqlCeCommand sqlCommand)
        {
            //Setting command connection
            sqlCommand.Connection = generateConnection();

            //Execute command
            sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Connection.Close();
        }

        private static SqlCeConnection generateConnection()
        {

            // Getting connection 
            string sqlConnectionString = Settings.Default.DataBaseConecctionString;

            // Setting connection
            SqlCeConnection sqlConnection = new SqlCeConnection(sqlConnectionString);

            return sqlConnection;
            
        }
    }
}