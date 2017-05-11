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
    }
}
