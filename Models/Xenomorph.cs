using System;

namespace NinjasInSpace.Models
{
    public class Xenomorph : Enemy
    {
        public Xenomorph(string name) : base(name)
        {
            Strength = 10;
            Dexterity = 10;
            Intelligence = 10;
            health = 500;
        }

        public override void Attack(Hero target)
        {   
            base.Attack(target);
            if (target.Health > 0)
            {
                Random d20 = new Random();
                if (d20.Next(1,21) >= 12)
                {
                    int acid = 100;
                    target.Health -= acid;
                    Console.WriteLine($"Acid! The goggles do nothing! {target.Name} melts for {acid} HP!");
                }
                if (target.Health <= 0)
                {
                    target.Health = 0;
                    Console.WriteLine($"{target.Name} has perished!");
                }
            }
        }
    }
}