using MySql.Data.MySqlClient;

namespace KINO_Alikin_2.Classes.Common
{
    public class Connection
    {
        public static readonly string config = "server127.0.0.1;Port=3307;uid=root;pwd=;database=kino;"
        public MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(config);
            connection.Open();

            return connection;
        }
        public MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }
        public void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
