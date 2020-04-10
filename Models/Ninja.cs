using System;

namespace NinjasInSpace.Models
{
    public class Ninja : Hero
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 10;
        }

        public override void Attack(Enemy target)
        {
            target.Health -= Dexterity*5;
            Console.WriteLine($"{Name} viciously ninjas {target.Name} for {Dexterity*5} damage!");
            Random dice = new Random();
            int d20 = dice.Next(1,21);
            if (d20 >= 17)
            {
                target.Health -= 10;
                Console.WriteLine($"{Name} rolls for extra damage! {d20}! 10 extra damage!");
            }
            else
            {
                Console.WriteLine($"{Name} rolls for extra damage! {d20}! No extra damage!");
            }
            if (target.Health <= 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} has perished!");
            }
        }

        public void Backstab(Enemy target)
        {
            Random die = new Random();
            int d20 = die.Next(1, 21);
            Console.WriteLine($"Dexterity check! {d20}!");
            if (d20 >= 20 - Dexterity)
            {
                target.Health -= Dexterity*15;
                Console.WriteLine($"{Name} viciously backstabs {target.Name} for {Dexterity*15} HP!");
            }
            else
            {
                Health -= Dexterity*5; 
                Console.WriteLine($"{target.Name} sees it coming and smugly trips {Name} for {Dexterity*5} HP!");
            }
            if (target.Health <= 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} has perished!");
            }
            if (Health <= 0)
            {
                Health = 0;
                Console.WriteLine($"{Name} has perished!");
            }
        }

    }
}