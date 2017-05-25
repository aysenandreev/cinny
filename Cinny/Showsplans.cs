using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinny
{

    [Serializable]

    class Showsplans
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _season;

        public string Season
        {
            get { return _season; }
            set { _season = value; }
        }

        public Showsplans(string name, string season)
        {
            _name = name;
            _season = season;
        }

        public string ShowPlans()
        {
            return string.Format("* {0}, season {1}", Name, Season);
        }
    }
}
