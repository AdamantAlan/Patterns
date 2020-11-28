using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water;

namespace Bottle
{
    class SpriteBottle:AbstractBottle
    {
        internal override void Pour(AbstractWater sprite)
        {
            Console.WriteLine($"Water is {sprite.Name}");
        }
    }
}
