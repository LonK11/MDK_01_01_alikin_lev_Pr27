using KINO_Alikin_2.Modell;
using MySql.Data.MySqlClient;
using KINO_Alikin_2.Classes.Common;
using System.Windows.Documents;
using System.Collections.Generic;

namespace KINO_Alikin_2.Classes
{
    public  class KinoteatrContext : Kinoteatr
    {
        public KinoteatrContext(int id, string name, int countZal, int count) : base(id, name, countZal, count) { }

        public static List<KinoteatrContext> Select()
        {
            List<KinoteatrContext> AllKinoteatrs = new List<KinoteatrContext>();
            string SQL = "SELECT * FROM `Kinoteatr`;";
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader Data = Connection.Query(SQL, connection);
            while (Data.Read())
            {
                AllKinoteatrs.Add(new KinoteatrContext(
                    Data.GetInt32(0),
                    Data.GetString(1),
                    Data.GetInt32(2),
                    Data.GetInt32(3)
                    ));
            }
            Connection.CloseConnection(connection);
            return AllKinoteatrs;
        }
        public  void Add()
        {
            string SQL = "INSERT INTO " +
                            "`Kinoteatr`( " +
                                "`name`, " +
                                "`count_zal`, " +
                                "`count`)" +
                         "VALUES" +
                            $" ('{this.name}', " +
                            $"{this.countZal}, " +
                            $"{this.count})";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = "UPDATE " +
                            "`Kinoteatr` " +
                        "SET " +
                            $"`name`='{this.name}'," +
                            $"`count_zal`={this.countZal}," +
                            $"`count`={this.count}" +
                        " WHERE " +
                            $"`id`={this.id}";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
        public void Delete()
        {
            string SQL = $"DELETE FROM `Kinoteatr` WHERE `id` = {this.id}";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
    }
}
