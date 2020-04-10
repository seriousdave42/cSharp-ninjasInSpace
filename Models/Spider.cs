using System;

namespace NinjasInSpace.Models
{
    public class Spider : Enemy
    {
        public Spider(string name) : base(name)
        {
            Dexterity = 15;
        }

        public override void Attack(Hero target)
        {   
            base.Attack(target);
            Random d20 = new Random();
            if (d20.Next(1,21) >= 18 && target.Health > 0)
            {
                target.Dexterity -= 6;
                Console.WriteLine($"{target.Name} becomes entangled in a web!");
            }
        }
    }
}