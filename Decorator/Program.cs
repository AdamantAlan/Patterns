using System;
using System.Diagnostics;

namespace Decorator
{
     class Program
    {
        delegate void Key(object sender, int key);
        static event Key DownKey;
        delegate SuperUser Super(object sender);
        static event Super SuperUserUpgrade;
        delegate User NoSuperUser();
        static event NoSuperUser SuperUserDowngrade;
        static void Main(string[] args)
        {
            DefaultRole u = new User();
            SuperUserUpgrade += SuperUserUpgradeHandle;
            SuperUserDowngrade += SuperUserDowngradeHandle;
            DownKey += DownKeyHandle;
         
            while (true)
            {
                if(u is User)
                {
                    Console.WriteLine("Вы в режиме обычного пользователя, вам доступно:");
                    Console.WriteLine(@"   1. Открыть нотпад");
                    Console.WriteLine(@"   2. Открыть калькулятор");
                    Console.WriteLine(@"   3. Секретная кнопка, стать суперюзером");
                }
                if (u is SuperUser)
                {
                    Console.WriteLine("Вы в режиме супер пользователя, вам доступно:");
                    Console.WriteLine(@"   1. Открыть нотпад");
                    Console.WriteLine(@"   2. Открыть калькулятор");
                    Console.WriteLine(@"   3. Секретная кнопка, стать юзером");
                    Console.WriteLine(@"   4. Открыть cmd");
                    Console.WriteLine(@"   5. Перезапустить проводник");
                }
                int key = int.Parse(Console.ReadLine());
                if (key == 3)
                    if (u is User)
                        u = SuperUserUpgrade(u);
                    else
                        u = SuperUserDowngrade();
                if(key > 3 & u is SuperUser)
                    new SuperUser(u).DownKey(key);
                else
                    DownKey(u, key);
            }
        }
        abstract class DefaultRole
        {
            abstract public void StartNotepad();
            abstract public void StartCalc();
        }
        class User : DefaultRole
        {
            public override void StartCalc()=> Process.Start("calc");

            public override void StartNotepad()=> Process.Start("notepad");
        }
       abstract class DecoratorDefaultRoleToSuperUser:DefaultRole
        {
            protected readonly DefaultRole defRole;
            abstract public void StartCmd();
            abstract public void StartExplorer();
            public DecoratorDefaultRoleToSuperUser(DefaultRole u) => defRole = u;
        }
        class SuperUser:DecoratorDefaultRoleToSuperUser
        {
            public SuperUser(DefaultRole u):base(u) { }
            public override void StartCalc() => defRole.StartCalc();
            public override void StartNotepad() => defRole.StartNotepad();
            public override void StartCmd()
            {
                Process.Start("cmd");
            }
            public override void StartExplorer()
            {
                Process.Start("explorer");
            }
            public void DownKey(int key)
            {
                if (key == 4)
                    StartCmd();
                if (key == 5)
                    StartExplorer();
            }
        }
        static void DownKeyHandle(object sender, int key)
        {
            DefaultRole u = sender as User;
            if (key == 1)
                u.StartNotepad();
            if (key == 2)
                u.StartCalc();
        }
        static SuperUser SuperUserUpgradeHandle(object sender)=> new(sender as DefaultRole);
        static User SuperUserDowngradeHandle() => new();
     }
}
