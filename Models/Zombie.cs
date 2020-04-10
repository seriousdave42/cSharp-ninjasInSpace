using System;

namespace NinjasInSpace.Models
{
    public class Zombie : Enemy
    {
        public Zombie(string name) : base(name)
        {
            Strength = 15;
            Dexterity = 9;
            health = 300;
        }

        public override void Attack(Hero target)
        {   
            base.Attack(target);
            Random d20 = new Random();
            if (d20.Next(1,21) >= 18 && target.Health > 0)
            {
                target.Health = target.Health/2;
                Console.WriteLine($"{target.Name} catches the plague and loses half of their HP!");
            }
        }
    }
}