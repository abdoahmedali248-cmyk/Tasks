using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero_Battle_Arena
{
   public class Warrior : Hero
    {
        public Warrior(string name, int hp, int dmg) : base(name, hp, dmg) { }

        public override int Attack()
        {
            Console.WriteLine($"{Name} hits with sword ⚔");
            return Dmg + 5;
        }
    }
}
