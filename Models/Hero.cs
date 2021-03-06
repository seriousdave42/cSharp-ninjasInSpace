using System;

namespace NinjasInSpace.Models
{
    public abstract class Hero
    {
        public string Name;
        public int Dexterity;
        public int Strength;
        public int Intelligence;
        public int MaxHealth;
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

        public Hero(string name)
        {
            Name = name;
            Dexterity = 5;
            Strength = 5;
            Intelligence = 5;
            MaxHealth = 100;
            health = 100;
        }

        // public abstract void SayName();

        public void ShowStats()
        {
            Console.WriteLine($"Name: {Name}\nDexterity: {Dexterity}\nStrength: {Strength}\nIntelligence: {Intelligence}\nMax Health: {MaxHealth}");
        }

        public virtual void Attack(Enemy target)
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