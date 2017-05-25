using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cinny
{
    [Serializable]
public class Person
    {
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Person(string email, string password)
        {
            _email = email;
            _password = password;
        }

        public string Show()
        {
            return string.Format("{0} {1}",  Email, Password);
        }
    }
}
