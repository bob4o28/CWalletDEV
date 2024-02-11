using MySql.Data.MySqlClient;
using Renci.SshNet;

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

            // Database connection info
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
                    var port = new ForwardedPortLocal("127.0.0.1", (uint)dbPort, dbServer, (uint)dbPort);
                    client.AddForwardedPort(port);
                    port.Start();

                    string connStr = $"Server=127.0.0.1;Port={port.BoundPort};Database={dbName};Uid={dbUsername};Pwd={dbPassword};";
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
    }
}