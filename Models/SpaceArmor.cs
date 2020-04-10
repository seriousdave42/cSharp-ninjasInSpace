using NinjasInSpace.Interfaces;

namespace NinjasInSpace.Models
{
    public class SpaceArmor : Equipment, IEquipable
    {
        public int HealthBonus;

        public SpaceArmor(string name, int health) : base(name)
        {
            HealthBonus = health;
            Desc = $"This increases a character's max health by {health}.";
        }

        public void Equip(Hero target)
        {
            target.MaxHealth += HealthBonus;
        }
    }
}