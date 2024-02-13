using MySql.Data.MySqlClient;
using Renci.SshNet;
using System.Data;
using System;
using System.Reflection.Emit;
using System.Windows.Media.Animation;

namespace CWalletDEV
{
    public class DbConnector
    {
        public MySqlConnection ConnectToDbWithSshTunnel()
        {
            
            //// Database connection info
            string dbServer = "83.229.87.97";
            string dbUsername = "dev";
            string dbPassword = "Cwallet.dev.24";
            string dbName = "cwallet";
            int dbPort = 3306;

            string connStr = $"Server={dbServer};Port={dbPort};Database={dbName};Uid={dbUsername};Pwd={dbPassword};";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();

            return conn;
        }
        public void AddUser(string userName, string password)
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return;

                string query = "INSERT INTO Users (UserName, Password) VALUES (@UserName, @Password)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CheckLogin(string userName, string password)
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return;

                string query = "SELECT  FROM Users WHERE UserName = @UserName AND Password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int count = (int)cmd.ExecuteScalar();
                    return;

                }
            }
        }
    }
}