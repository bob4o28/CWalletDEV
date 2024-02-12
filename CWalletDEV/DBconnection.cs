using MySql.Data.MySqlClient;
using Renci.SshNet;
using System.Reflection.Emit;

namespace CWalletDEV
{
    public class DbConnector
    {
        public MySqlConnection ConnectToDbWithSshTunnel()
        {
            // SSH connection info
            string sshHost = "83.229.87.97";
            string sshUsername = "root";
            string sshPassword = "kamaCwallet!2023";
            int sshPort = 22;

            //// Database connection info
            string dbServer = "127.0.0.1";
            string dbUsername = "dev";
            string dbPassword = "Cwallet.dev.24";
            string dbName = "cwallet";
            int dbPort = 3306;

            using (var client = new SshClient(sshHost, sshPort, sshUsername, sshPassword))
            {
                client.Connect();

                if (client.IsConnected)
                {
                    var port = new ForwardedPortLocal(dbServer, (uint)dbPort, dbServer, (uint)dbPort);
                    client.AddForwardedPort(port);
                    port.Start();
                    
                    string connStr = $"Server={dbServer};Port={port.BoundPort};Database={dbName};Uid={dbUsername};Pwd={dbPassword};";
                    MySqlConnection conn = new MySqlConnection(connStr);
                    conn.Open();

                    return conn;
                }
                else
                {
                    // Handle SSH connection failure
                    return null;
                }
            }
        }
        public void CreateUser(string username, string password)
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn != null)
                {
                    string sql = "INSERT INTO users (username, password) VALUES (@username, @password)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // Handle database connection failure
                }
            }
        }
        public void CreateTable()
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn != null)
                {
                    string sql = "CREATE TABLE IF NOT EXISTS users (username VARCHAR(255), password VARCHAR(255))";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    
                }
            }
        }
    }
}