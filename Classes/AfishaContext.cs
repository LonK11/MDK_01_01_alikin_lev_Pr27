using KINO_Alikin_2.Classes.Common;
using KINO_Alikin_2.Modell;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace KINO_Alikin_2.Classes
{
    public class AfishaContext : afisha
    {
       public AfishaContext(int id, string name, DateTime time, int price, int idKinoteatr) : base (id, name, time, price, idKinoteatr) { }

        public static List<AfishaContext> Select()
        {
            List<AfishaContext> allAfishas = new List<AfishaContext>();
            string SQL = "SELECT * FROM `afisha`;";
            MySqlConnection connection = Connection.OpenConnection();
            MySqlDataReader Data = Connection.Query(SQL, connection);
            while (Data.Read())
            {
                allAfishas.Add(new AfishaContext(
                    Data.GetInt32(0),
                    Data.GetString(2),
                    Data.GetDateTime(3),
                    Data.GetInt32(4),
                    Data.GetInt32(1)
                ));
            }
            Connection.CloseConnection(connection);
            return allAfishas;
        }
        public void Add()
        {
            string SQL = "INSERT INTO " +
                            "`afisha`( " +
                                "`id_kinoteatr`, " +
                                "`name`, " +
                                "`time`, " +
                                "`price`)" +
                         "VALUES" +
                            $" ({this.idKinoteatr}, " +
                            $"'{this.name}', " +
                            $"'{this.time.ToString("yyyy-MM-dd HH:mm:ss")}', " +
                            $"{this.price})";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
        public void Update()
        {
            string SQL = "UPDATE " +
                            "`afisha` " +
                        "SET " +
                            $"`id_kinoteatr`= {this.idKinoteatr}," +
                            $"`name`='{this.name}'," +
                            $"`time`='{this.time.ToString("yyyy-MM-dd HH:mm:ss")}'," +
                            $"`price`={this.price}" +
                        " WHERE " +
                            $"`id`={this.id}";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
        public void Delete()
        {
            string SQL = $"DELETE FROM `afisha` WHERE `id` = {this.id}";
            MySqlConnection connection = Connection.OpenConnection();
            Connection.Query(SQL, connection);
            Connection.CloseConnection(connection);
        }
    }
}
