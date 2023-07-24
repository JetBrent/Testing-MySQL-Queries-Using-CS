using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLTest
{
    internal class AppUser
    {
        public string Userid;
        public string Username;
        public string Department;
        public string DeptPosition;
        public string AccessRole;

        public AppUser(string userid, string username, string department, string deptPosition, string accessRole)
        {
            Userid = userid;
            Username = username;
            Department = department;
            DeptPosition = deptPosition;
            AccessRole = accessRole;
        }
    }
}
