using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinny
{

    [Serializable]

    class Moviesplans
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Moviesplans(string name)
        {
            _name = name;
        }

        public string Showmplans()
        {
            return string.Format("* {0}", Name);
        }
    }
}
