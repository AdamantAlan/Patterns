using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    interface IDamageStrategy
    {
        int DealDamage();
    }
    class Sword : IDamageStrategy
    {
        public int DealDamage() => 15;
    }
    class Arrow : IDamageStrategy
    {
        public int DealDamage() => 30;
    }
    class Magic : IDamageStrategy
    {
        public int DealDamage() => 55;
    }

    class DamageContext
    {
        private IDamageStrategy _strategy;
        public DamageContext(IDamageStrategy strategy) => _strategy = strategy;
        public void SetNewModeDamage(IDamageStrategy strategy) => _strategy = strategy;
        public void DealDamage() => _strategy.DealDamage();
    }
}
