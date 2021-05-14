using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game for pattern strategy");
            Console.Write("Enter your name:");
            var name = Console.ReadLine();
            Person player = new Player(name,100);
            Person boss = new Boss("BOSS",100);
            // Здесь избыточность кода, надо бы вынести в отдельные методы, но это просто пример, так что не буду ;)
            while (true)
            {
                Console.WriteLine($"{boss.name} - heal:{boss.GetHealf}");
                Console.WriteLine($"{player.name} - heal:{player.GetHealf}");
                Console.WriteLine("1 - Sword, 2 - Arrow, 3 - magic");
              
                var typeDamage =int.Parse(Console.ReadLine());
                if (typeDamage == 1)
                    boss.TakeDamage(player.DealDamage(new Sword()));
                if (typeDamage == 2)
                    boss.TakeDamage(player.DealDamage(new Arrow()));
                if (typeDamage == 3)
                    boss.TakeDamage(player.DealDamage(new Magic()));
                typeDamage = new Random().Next(1, 3);
                if (typeDamage == 1)
                    player.TakeDamage(boss.DealDamage(new Sword()));
                if (typeDamage == 2)
                    player.TakeDamage(boss.DealDamage(new Arrow()));
                if (typeDamage == 3)
                    player.TakeDamage(boss.DealDamage(new Magic()));
                if (boss.GetHealf <= 0 || player.GetHealf <= 0)
                    break;
            }
            if (boss.GetHealf < 0)
                Console.WriteLine($"{player.name} win");
            if (player.GetHealf < 0)
                Console.WriteLine($"{boss.name} win");
        }
    }
}
