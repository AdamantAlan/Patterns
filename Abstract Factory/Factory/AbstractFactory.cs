using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bottle;
using Water;
namespace Factory
{
   abstract class AbstractFactory
    {
        AbstractBottle _bottle;
        AbstractWater _water;

     internal abstract  AbstractBottle CreateBottle();
     internal abstract AbstractWater CreateWater();

    }
}
