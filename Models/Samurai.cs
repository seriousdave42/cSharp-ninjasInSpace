using System;

namespace NinjasInSpace.Models
{
    public class Samurai : Hero
    {
        public Samurai(string name) : base(name)
        {
            MaxHealth = 200;
            health = 200;
        }

        public override void Attack(Enemy target)
        {   
            base.Attack(target);
            if (target.Health < 50 && target.Health > 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} bleeds out due to all the samurai stuff!");
                Console.WriteLine($"{target.Name} has perished!");
            }
        }

        public void Meditate()
        {
            if (health < MaxHealth)
            {
            health = MaxHealth;
            Console.WriteLine($"{Name} viciously meditates and returns to full health!");
            }
            else
            {
            Console.WriteLine($"{Name} viciously meditates, but is already at full health!");
            }
        }
    }
}