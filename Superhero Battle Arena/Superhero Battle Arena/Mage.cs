using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero_Battle_Arena
{
   public class Mage : Hero
    {
        public Mage(string name, int hp, int dmg) : base(name, hp, dmg) { }

        public override int Attack()
        {
            Console.WriteLine($"{Name} casts fire 🔥");
            return Dmg + 10;
        }
    }
}
