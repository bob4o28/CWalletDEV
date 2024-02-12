using MySql.Data.MySqlClient;
using Renci.SshNet;
using System.Data;
using System;
using System.Reflection.Emit;

namespace CWalletDEV
{
    public class DbConnector
    {
        public MySqlConnection ConnectToDbWithSshTunnel()
        {
            // SSH connection info
            //string sshHost = "83.229.87.97";
            //string sshUsername = "root";
            //string sshPassword = "kamaCwallet!2023";
            //int sshPort = 22;

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
            //using (var client = new SshClient(sshHost, sshPort, sshUsername, sshPassword))
            //{
            //    client.Connect();

            //    if (client.IsConnected)
            //    {
            //        var port = new ForwardedPortLocal(dbServer, (uint)dbPort, dbServer, (uint)dbPort);
            //        client.AddForwardedPort(port);
            //        port.Start();
                    
                    
            //    }
            //    else
            //    {
            //        // Handle SSH connection failure
            //        return null;
            //    }
            //}
        }
        public void AddUser(string userName, string password)
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    string query = "INSERT INTO Users (UserName, Password) VALUES (@UserName, @Password)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}