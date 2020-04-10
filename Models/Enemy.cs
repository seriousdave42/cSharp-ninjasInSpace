using System;

namespace NinjasInSpace.Models
{
    public class Enemy
    {
        public string Name;
        public int Dexterity;
        public int Strength;
        public int Intelligence;
        protected int health;

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }

        }

        public Enemy(string name)
        {
            Name = name;
            Dexterity = 5;
            Strength = 5;
            Intelligence = 5;
            health = 100;
        }

        // public abstract void SayName();

        public virtual void ShowStats()
        {
            Console.WriteLine($"Name: {Name}\nDexterity: {Dexterity}\nStrength: {Strength}\nIntelligence: {Intelligence}\nHealth: {health}");
        }

        public virtual void Attack(Hero target)
        {
            target.Health = target.Health - this.Strength*5;
            Console.WriteLine($"{this.Name} viciously strikes {target.Name} for {this.Strength*5} damage!");
            if (target.Health <= 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} has perished!");
            }
        }
    }
}