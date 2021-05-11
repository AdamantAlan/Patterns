using System;

namespace Singlton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton single = Singleton.Instance(12,"stub");
            Singleton single2 = Singleton.Instance(123,"no stub");
            if (single == single2)
                Console.WriteLine($"Singleton {single.GetHashCode()} == {single2.GetHashCode()}");
        }
    }
}
