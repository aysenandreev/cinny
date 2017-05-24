using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinny
{

    [Serializable]

    class Shows
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

        private string _episode;

        public string Episode
        {
            get { return _episode; }
            set { _episode = value; }
        }

        private string _time;

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public Shows(string name, string season, string episode, string time)
        {
            _name = name;
            _season = season;
            _episode = episode;
            _time = time;
        }

        public string Show()
        {
            return string.Format("* {0}, season {1}, episode {2}, {3}", Name, Season, Episode, Time);
        }
    }
}
