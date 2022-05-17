using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private String name;
        private String password;
        private String _errorLog;
        public delegate void ActionOnError(string errorMsg);
        ActionOnError _errorfunc;

        public LoginValidation(string name, string password, ActionOnError aError)
        {
            this.name = name;
            this.password = password;
            _errorfunc = aError;
        }

        public static string currentUserUsername
        {
            private set;
            get;
        }

        public static UserRoles currentUserRole
        {
            private set;
            get;
        }

        public bool ValidateUserInput(ref User user)
        {
            User currentUser;
            currentUser = user;
            Boolean emptyUserName;

            emptyUserName = user.name.Equals(String.Empty);

            if (emptyUserName == true)
            {
                currentUserRole = UserRoles.Anonymous;
                //    _errorLog = "Не е посочено потребителско име";
                _errorLog = "Username is not entered";
                _errorfunc(_errorLog);
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = user.password.Equals(String.Empty);

            if (emptyPassword == true)
            {
                currentUserRole = UserRoles.Anonymous;
                //    _errorLog = "Не е посочена парола";
                _errorLog = "Password is not entered";
                _errorfunc(_errorLog);
                return false;
            }

            int shortLengthUserName;
            shortLengthUserName = user.name.Length;

            if (shortLengthUserName <= 5)
            {
                currentUserRole = UserRoles.Anonymous;
                //    _errorLog = "Въведеното потребителско име е с по-малко от 5 символи";
                _errorLog = "Username has less than 5 characters";
                _errorfunc(_errorLog);
                return false;
            }

            int shortLengthUserPassword;
            shortLengthUserPassword = user.password.Length;

            if (shortLengthUserPassword <= 5)
            {
                currentUserRole = UserRoles.Anonymous;
                //    _errorLog = "Въведенaтa парола е с по-малко от 5 символи";
                _errorLog = "Password has less than 5 characters";
                _errorfunc(_errorLog);
                return false;
            }

            if (UserData.IsUserPassCorrect(user.name, user.password) == null)
            {
                currentUserRole = UserRoles.Anonymous;
                _errorLog = "Not correct User or PW";
                _errorfunc(_errorLog);
                return false;
            }
            else
            {
                currentUser = UserData.IsUserPassCorrect(user.name, user.password);
                currentUserRole = (UserRoles)currentUser.role;
                return true;
            }
        }

    }
}
