using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinny
{

    [Serializable]

    class Movies
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _rating;

        public string Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public Movies (string name, string rating)
        {
            _name = name;
            _rating = rating;
        }

        public string Showm()
        {
            return string.Format("* {0}, season {1}", Name, Rating);
        }
    }
}
