using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water;
namespace Bottle
{
    class ColaBottle: AbstractBottle
    {
        internal override void Pour(AbstractWater cola)
        {
            Console.WriteLine($"Water is {cola.Name}");
        }
    }
}
