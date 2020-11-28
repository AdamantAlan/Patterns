using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bottle;
using Water;
namespace Factory
{
    class CocaColaFactory: AbstractFactory
    {
        internal override AbstractBottle CreateBottle()
        {
            return new ColaBottle();
        }
        internal override AbstractWater CreateWater()
        {
            return new ColaWater();
        }
    }
}
