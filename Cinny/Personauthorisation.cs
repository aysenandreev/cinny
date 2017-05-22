using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinny
{
    [Serializable]
    class Personauthorisation
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

        public Personauthorisation(string email, string password)
        {
            _email = email;
            _password = password;
        }
    }
}
