using System;

namespace Singlton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton single = new Singleton();
            Singleton single2 = new Singleton();
        }
    }
}
