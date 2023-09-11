using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Game
    {
        struct BoolWeapon
        {
            bool weapon;
        }

        struct Monster
        {
            public string Name;
            public float Health;
            public float Damage;
            public float Defense;
            public float Stamina;
        }

        float FightNite(Monster attacker, Monster defender)
        {
            float totalDamage = attacker.Damage - defender.Defense;

            return defender.Health - totalDamage;
        }

        void Fite(ref Monster monster1, ref Monster monster2)
        {
            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster1.Name + " Punches " + monster2.Name + "!");
            monster2.Health = FightNite(monster1, monster2);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);

            Console.WriteLine(monster2.Name + " Punches " + monster1.Name + "!");
            monster1.Health = FightNite(monster2, monster1);
            Console.ReadKey(true);

            PrintStats(monster1);
            PrintStats(monster2);
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name:" + monster.Name);
            Console.WriteLine("Health:" + monster.Health);
            Console.WriteLine("Damage:" + monster.Damage);
            Console.WriteLine("Defense:" + monster.Defense);
            Console.WriteLine("Stamina:" + monster.Stamina);
        }

        float HealMon(Monster healReceiver, float healAmount)
        {
            float heal = healReceiver.Health + healAmount;

            if (heal > 3230)
            {
                heal = 3230;
            }

            return heal;
        }

        public void Run()
        {
            
            Monster JoePable;
            JoePable.Name = "JoePable";
            JoePable.Health = 2119f;
            JoePable.Damage = 246.90f;
            JoePable.Defense = .9f;
            JoePable.Stamina = 3f;

            Monster Joehna;
            Joehna.Name = "Joehna";
            Joehna.Health = 3230f;
            Joehna.Damage = 357.89f;
            Joehna.Defense = 2.1f;
            Joehna.Stamina = 4;

            Monster Jach;
            Jach.Name = "Jach";
            Jach.Health = 1008f;
            Jach.Damage = 135.91f;
            Jach.Defense = -1.1f;
            Jach.Stamina = 2;
            Console.Clear();

            PrintStats(Jach);

            Jach.Health = HealMon(Jach, 100f);
            
            PrintStats(Jach);
            Console.ReadKey(true);
            Console.Clear();

            Fite(ref JoePable, ref Joehna);

            Console.Clear();

            Fite(ref JoePable, ref Joehna);

            Console.Clear();
        }
    }
}
