using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinny
{
    [Serializable]
public class Person
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

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

        public Person(string name, string email, string password)
        {
            _name = name;
            _email = email;
            _password = password;
        }
    }
}
