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
        public int stub1 { get; }
        internal string stub2 { get; }
    private Singleton(int s1, string s2) { stub1 = s1; stub2 = s2; }
        public static Singleton Instance( int s1,string s2)
        {
            if (_instance == null)
            {
                return _instance = new Singleton(s1,s2);
            }
            else
                return _instance;
        }
    }
}
