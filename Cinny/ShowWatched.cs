using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinny
{
    class ShowWatched
    {
        private string _showname;

        public string Showname
        {
            get { return _showname; }
            set { _showname = value; }
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

        public ShowWatched(string showname, string season, string episode, string time)
        {
            _showname = showname;
            _season = season;
            _episode = episode;
            _time = time;
        }
    }
}
