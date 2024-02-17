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

        public void BasicRecordAdd(string Value, string Currency, DateTime chosenDate)
        {
            using (MySqlConnection conn = ConnectToDbWithSshTunnel())
            {
                if (conn == null || conn.State != ConnectionState.Open)
                    return;

                // Check if a row with the chosen date exists
                string checkQuery = "SELECT COUNT(*) FROM MoneyHolders WHERE UserID = @UserId AND Date = @ChosenDate";
                using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@UserId", UserId);
                    checkCmd.Parameters.AddWithValue("@ChosenDate", chosenDate);
                    int dateExists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (dateExists > 0)
                    {
                        // If the date exists, update the Cash column
                        string updateQuery = "UPDATE MoneyHolders SET Cash = @Value WHERE UserID = @UserId AND Date = @ChosenDate";
                        using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@UserId", UserId);
                            updateCmd.Parameters.AddWithValue("@ChosenDate", chosenDate);
                            updateCmd.Parameters.AddWithValue("@Value", Value);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // If the date does not exist, insert a new row
                        string insertQuery = "INSERT INTO MoneyHolders (UserID, Date, Cash) VALUES (@UserId, @ChosenDate, @Value)";
                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.AddWithValue("@UserId", UserId);
                            insertCmd.Parameters.AddWithValue("@ChosenDate", chosenDate);
                            insertCmd.Parameters.AddWithValue("@Value", Value);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }


        public void MainWinStartUp()
        {
           
        }
    }
}