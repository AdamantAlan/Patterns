using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Channels;

namespace Singlton
{
    class Singleton
    {
        private static Singleton _instance = null;
        public static Singleton Instance()
        {
            if (_instance == null)
            {
                return _instance = new Singleton();
            }
            else
                return _instance;
        }
    }
}
