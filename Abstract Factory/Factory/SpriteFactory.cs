using Bottle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Water;
using Bottle;
namespace Factory
{
    class SpriteFactory:AbstractFactory
    {
        internal override AbstractBottle CreateBottle()
        {
            return new SpriteBottle();
        }
        internal override AbstractWater CreateWater()
        {
            return new SpriteWater();
        }
    }
}
