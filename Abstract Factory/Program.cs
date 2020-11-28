using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
namespace Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Client Cola = new Client(new CocaColaFactory());
            Cola.Run();
            Client Sprite = new Client(new SpriteFactory());
            Sprite.Run();
        }
    }
}
