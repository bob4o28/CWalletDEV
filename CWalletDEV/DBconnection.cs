using MySql.Data.MySqlClient;
using Renci.SshNet;
using System.Data;
using System;
using System.Reflection.Emit;
using System.Windows.Media.Animation;
using LiveCharts;
using System.Collections.Generic;

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

        public void AddUser(string userName, string userLastname, string userEmail, string password)
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return;

                string query = "INSERT INTO Users (UserName, UserLastName, Email, Password) VALUES (@UserName, @UserLastName, @Email, @Password)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@UserLastName", userLastname);
                    cmd.Parameters.AddWithValue("@Email", userEmail);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool CheckLogin(string userEmail, string password)
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return false;

                string query = "SELECT COUNT(*) FROM Users WHERE Email = @UserEmail AND Password = @Password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                    cmd.Parameters.AddWithValue("@Password", password);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;  // Return true if there is a matching username and password
                }
            }
        }

        public static int UserId;

        public void SetUserId(string userEmail)
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return;

                string query = "SELECT idUsers FROM Users WHERE Email = @UserEmail";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserEmail", userEmail);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        UserId = Convert.ToInt32(result);
                }
            }
        }

        public void AddPlannedPayment(string nameOfPP, decimal worthOfPP, DateTime dueDate)
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return;
                DbConnector dbConnector = new DbConnector();
                string query = "INSERT INTO PlannedPayments (IdUsers, NameOfPP, WorthOfPP, DueDatte) VALUES (@UserId, @NameOfPP, @WorthOfPP, @DueDatte)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@NameOfPP", nameOfPP);
                    cmd.Parameters.AddWithValue("@WorthOfPP", worthOfPP);
                    cmd.Parameters.AddWithValue("@DueDatte", dueDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void FirstUserStart()
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return;
                string query = "INSERT INTO MoneyHolders (UserID, Date) VALUES (@UserId, @CurDate)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@CurDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void MainWinStartUp()
        {
           
        }
    }
}