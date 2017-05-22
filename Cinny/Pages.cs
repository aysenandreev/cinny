﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinny
{
    static class Pages
    {
        private static StartPage _startPage = new StartPage();
        private static SignupPage _signupPage = new SignupPage();
        private static ShowswatchedPage _showswatchedPage = new ShowswatchedPage();
        private static ShowssearchPage _showssearchPage = new ShowssearchPage();
        private static MoviessearchPage _moviessearchPage = new MoviessearchPage();

        public static StartPage StartPage
        {
            get
            {
                return _startPage;
            }
        }

        public static SignupPage SignupPage
        {
            get
            {
                return _signupPage;
            }
        }

        public static ShowswatchedPage ShowswatchedPage
        {
            get
            {
                return _showswatchedPage;
            }
        }

        public static ShowssearchPage ShowssearchPage
        {
            get
            {
                return _showssearchPage;
            }
        }

        public static MoviessearchPage MoviessearchPage
        {
            get
            {
                return _moviessearchPage;
            }
        }
    }
}
