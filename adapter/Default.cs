using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adapter
{
    interface ITransport
    {
        void Drive();
    }
    interface IAnimal
    {
        void Run();
    }
    class Auto : ITransport
    {
        public void Drive() => Console.WriteLine("Машина едет");
    }
    class Horse : IAnimal
    {
        public void Run() => Console.WriteLine("Лошадь бежит");
    }
    class Driver
    {
        public void Travel(ITransport transport) => transport.Drive();
    }
    //adapter
    class AdapterToTransport : ITransport
    {
        private readonly IAnimal _h;
        public AdapterToTransport(IAnimal h) => _h = h;
        public void Drive() => _h.Run();
    }
}
