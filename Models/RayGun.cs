using NinjasInSpace.Interfaces;

namespace NinjasInSpace.Models
{
    public class RayGun : Equipment, IEquipable
    {
        public int StrengthBonus;

        public RayGun(string name, int str) : base(name)
        {
            StrengthBonus = str;
            Desc = $"This increases a character's strength by {str}.";
        }

        public void Equip(Hero target)
        {
            target.Strength += StrengthBonus;
        }
    }
}