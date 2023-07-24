using MySql.Data.MySqlClient;

namespace MySQLTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQLConnect sqldb = new SQLConnect();
            MySqlConnection con = sqldb.Connect();
            /*
            var dbcontent = sqldb.QueryUserID(con, "OPS51793");
            foreach ( var item in dbcontent )
            {
                Console.WriteLine(item);
            }
            */
            var testuser = new AppUser("TEST000002", "TestUserName", "TestDepartment", "TestPosition", "TestAccessRole");
            sqldb.InsertQuery(con, testuser);
            Console.WriteLine("Print finished!");
            Console.ReadKey();
        }
    }
}

/*
 *          string connstring = "server=localhost;uid=root;password=MYBRENT.sql!;database=ousr";
            MySqlConnection con = new MySqlConnection(connstring);
            con.ConnectionString = connstring;
            con.Open();
            string selectusers = "SELECT * FROM users";
            MySqlCommand cmd = new MySqlCommand(selectusers, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("Connection Succesful!\n");
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
            Console.WriteLine("User ID | User Name | Department | Position | Access Role");
            foreach (string line in dblines)
            {
                Console.WriteLine(" ----------------------------------------");
                Console.WriteLine(line);
            }
            Console.WriteLine("\nPrint Successful!");
            Console.ReadKey();
*/