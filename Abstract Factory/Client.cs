using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using Bottle;
using Water;
namespace Abstract_Factory
{
    class Client
    {
        AbstractBottle _bottle;
        AbstractWater _water;

       internal Client(AbstractFactory factory)
        {
            _bottle = factory.CreateBottle();
            _water = factory.CreateWater();
        }

        internal void Run()
        {
            _bottle.Pour(_water);
        }

    }
}
