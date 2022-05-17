using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {

        static private User _testUser;
        static private List<User> _testUsers;


        static private void ResetTestUserData()
        {
            _testUsers = new List<User>();

            _testUsers.Add(new User("Webber", "123b566", 1231458, 1));           
            //_testUsers[0] = new User("Webber", "123b566", 1231458, 1);
            _testUsers[0].Created = DateTime.Today;
            _testUsers[0].ValidDate = DateTime.MaxValue;
            _testUsers.Add(new User("Sohnee", "12aq3b566", 123141258, 32));
            _testUsers[1].Created = DateTime.Today;
            _testUsers[1].ValidDate = DateTime.MaxValue;
            _testUsers.Add(new User("Richard", "123web566", 123142358, 4));
            _testUsers[2].Created = DateTime.Today;
            _testUsers[2].ValidDate = DateTime.MaxValue;
        }

        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }

            set { }

        }

        public static Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            for (int i = 0; i < _testUsers.Count; i++)
            {
                result.Add(_testUsers[i].name, i);
            }

            return result;
        }
        public static User IsUserPassCorrect(string username, string password)
        {
            Boolean found = false;
            ResetTestUserData();

            /*    StringBuilder sb = new StringBuilder();

                foreach (var action in _testUsers)
                {
                    sb.Append(action);
                }

                List<string> filteredActivities =
                    (from activity in _testUsers
                     where activity.Contains(filter)
                     select activity).ToList();
            */

            for (int i = 0; i < _testUsers.Count; i++)
            {
                if ((_testUsers[i].name.Equals(username)) && (_testUsers[i].password.Equals(password)) == true)
                    return _testUsers[i];
            }

            return null;
        }

        public static void SetUserActiveTo(int idx, DateTime dt)
        {
            _testUsers[idx].ValidDate = dt;

            /*     bool flag = false;

                 for (int i = 0; i < _testUsers.Count; i++)
                 {
                     if (_testUsers[i].name.Equals(username))
                     {
                         _testUsers[i].ValidDate = dt;
                     }
                 }

                 if (flag == false)
                 {
                     Console.WriteLine("No such an user found");
                 }
             */

        }

        public static void AssignUserRole(int idx, UserRoles newUserRole)
        {
            _testUsers[idx].role = newUserRole;

        }
    }
}
