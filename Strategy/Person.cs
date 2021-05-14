using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    abstract class Person
    {
        public readonly string name;
        private int healf;
        public int GetHealf { get => healf; }
        public  void TakeDamage(int loss) => healf -= loss;
        public int DealDamage(IDamageStrategy damage) =>  damage.DealDamage();
        public virtual void SeyHello() => Console.WriteLine("Hello");
        public Person(string name,int healf)
        {
            this.name = name;
            this.healf = healf;
        }
    }
    class Player : Person
    {
        public Player(string name, int healf):base(name,healf) { }
    }
    class Boss:Person
    {
        public Boss(string name, int healf) : base(name, healf) { }
        public override void SeyHello()
        {
            Console.WriteLine("AAA!");
        }
    }
}
