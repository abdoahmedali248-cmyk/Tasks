using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superhero_Battle_Arena
{
   public class Game
    {
        public void Start()
        {
            var heroes = CreateHeroes();
            ShowHeroes(heroes);
            StartBattle(heroes);
        }

        private List<Hero> CreateHeroes()
        {
            return new List<Hero>()
        {
            new Warrior("Thor", 100, 20),
            new Mage("Merlin", 80, 25),
            new Archer("Robin", 90, 15)
        };
        }

        private void ShowHeroes(List<Hero> heroes)
        {
            Console.WriteLine("=== HEROES ===");
            foreach (var h in heroes)
            {
                h.Show();
            }
        }

        private void StartBattle(List<Hero> heroes)
        {
            Console.WriteLine("\n=== BATTLE ===");

            Hero h1 = heroes[0];
            Hero h2 = heroes[1];

            while (h1.Hp > 0 && h2.Hp > 0)
            {
                AttackTurn(h1, h2);

                if (!IsAlive(h2))
                {
                    Console.WriteLine($"{h2.Name} LOST ❌");
                    break;
                }

                AttackTurn(h2, h1);

                if (!IsAlive(h1))
                {
                    Console.WriteLine($"{h1.Name} LOST ❌");
                    break;
                }
            }

            Console.WriteLine("\n=== END ===");
        }

        private void AttackTurn(Hero attacker, Hero defender)
        {
            int hit = attacker.Attack();
            defender.Hp -= hit;

            Console.WriteLine($"{defender.Name} HP: {defender.Hp}");
        }

        private bool IsAlive(Hero h)
        {
            return h.Hp > 0;
        }
    }
}
