using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero_Battle_Arena
{
   public abstract class Hero
    {
        public string Name { get; set; }

        private int hp;
        private int dmg;

        public int Hp
        {
            get { return hp; }
            set { hp = value < 0 ? 0 : value; }
        }

        public int Dmg
        {
            get { return dmg; }
            set { dmg = value; }
        }

        public Hero(string name, int hp, int dmg)
        {
            Name = name;
            Hp = hp;
            Dmg = dmg;
        }

        public void Show()
        {
            Console.WriteLine($"{Name} - HP: {Hp}, DMG: {Dmg}");
        }

        public abstract int Attack();

        public void Heal()
        {
            Hp += 20;
            Console.WriteLine($"{Name} healed +20");
        }

        public void Heal(int amount)
        {
            Hp += amount;
            Console.WriteLine($"{Name} healed +{amount}");
        }
    }
}
