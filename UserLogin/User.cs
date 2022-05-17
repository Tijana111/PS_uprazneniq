using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public string name;
        public string password;
        public long facultyNum;
        public UserRoles role;
        public DateTime Created;
        public DateTime ValidDate;

        public User()
        {
            this.name = "John";
            this.password = "ps123";
            this.facultyNum = 123422467;
            this.role = UserRoles.Student;
        }

        public User(string name, string password, long facultyNum, int role)
        {
            this.name = name;
            this.password = password;
            this.facultyNum = facultyNum;
            this.role = (UserRoles)role;
        }
    }
}
