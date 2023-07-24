using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MySQLTest
{
    internal class SQLConnect
    {
        public MySqlConnection Connect() 
        {
            string connstring = "server=localhost;uid=root;password=MYBRENT.sql!;database=ousr";
            MySqlConnection con = new MySqlConnection(connstring);
            con.ConnectionString = connstring;
            return con;
        }

        public List<string> ReadFromDatabase(MySqlConnection con)
        {
            con.Open();
            string selectusers = "SELECT * FROM users";
            MySqlCommand cmd = new MySqlCommand(selectusers, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            var dblines = new List<string>();
            while (reader.Read())
            {
                string userid = reader.GetString("userid");
                string username = reader.GetString("username");
                string department = reader.GetString("department");
                string deptposition = reader.GetString("deptposition");
                string accessrole = reader.GetString("accessrole");
                string line = $"{userid} | {username} | {department} | {deptposition} | {accessrole}";
                dblines.Add(line);
            }
            con.Close();
            return dblines;
        }

        public List<string> QueryAccessRole(MySqlConnection con, string acr)
        {
            con.Open();
            string selectusers = string.Format("SELECT * FROM users WHERE accessrole = '{0}'",acr);
            MySqlCommand cmd = new MySqlCommand(selectusers, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            var dblines = new List<string>();
            while (reader.Read())
            {
                string userid = reader.GetString("userid");
                string username = reader.GetString("username");
                string department = reader.GetString("department");
                string deptposition = reader.GetString("deptposition");
                string accessrole = reader.GetString("accessrole");
                string line = $"{userid} | {username} | {department} | {deptposition} | {accessrole}";
                dblines.Add(line);
            }
            if (reader.RecordsAffected > 0)
            {
                Console.WriteLine($"Query for Access Role {acr} is successful!");
            }
            else
            {
                Console.WriteLine($"Query for Access Role {acr} failed.");
            }
            con.Close();
            return dblines;
        }

        public List<string> QueryUserID(MySqlConnection con, string id)
        {
            con.Open();
            string selectusers = string.Format("SELECT * FROM users WHERE userid = '{0}'", id);
            MySqlCommand cmd = new MySqlCommand(selectusers, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            var dblines = new List<string>();
            while (reader.Read())
            {
                string userid = reader.GetString("userid");
                string username = reader.GetString("username");
                string department = reader.GetString("department");
                string deptposition = reader.GetString("deptposition");
                string accessrole = reader.GetString("accessrole");
                string line = $"{userid} | {username} | {department} | {deptposition} | {accessrole}";
                dblines.Add(line);
            }
            if (reader.RecordsAffected > 0)
            {
                Console.WriteLine($"Query for User ID {id} is successful!");
            }
            else
            {
                Console.WriteLine($"Query for User ID {id} failed.");
            }
            con.Close();
            return dblines;

        }

        public void InsertQuery(MySqlConnection con, AppUser usr)
        {
            con.Open();
            string insertuser = string.Format("INSERT INTO users (userid, username, department, deptposition, accessrole) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", usr.Userid, usr.Username, usr.Department, usr.DeptPosition, usr.AccessRole);
            MySqlCommand cmd = new MySqlCommand(insertuser, con);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.RecordsAffected > 0)
                {
                    Console.WriteLine("User details inserted successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to insert user details.");
                }
            }
            con.Close();
        }

    }
}
