using System;

namespace adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Driver d = new Driver();
            d.Travel(new AdapterToTransport(new Horse()));
            d.Travel(new Auto());
        }
    }
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
        public void Drive()
        {
            _h.Run();
        }
    }
}
