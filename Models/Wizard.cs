using System;

namespace NinjasInSpace.Models
{
    public class Wizard : Hero
    {
        public Wizard(string name) : base(name)
        {
            MaxHealth = 75;
            health = 75;
            Intelligence = 10;
        }

        public override void Attack(Enemy target)
        {
            target.Health = target.Health - Intelligence*5;
            Console.WriteLine($"{Name} viciously plasmaballs {target.Name} for {Intelligence*5} damage!");
            if (target.Health <= 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} has perished!");
            }
        }

        public void Shield(Hero target)
        {
            if (target.Health > 0)
            {
                target.Health += Intelligence*10;
                Console.WriteLine($"{Name} viciously shields {target.Name} for {Intelligence*10} HP!");
            }
            else
            {
                Console.WriteLine($"{target.Name} is too dead to be shielded");
            }
        }
    }
}