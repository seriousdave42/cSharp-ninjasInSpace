using NinjasInSpace.Interfaces;

namespace NinjasInSpace.Models
{
    public class GravBoots : Equipment, IEquipable
    {
        public int DexterityBonus;

        public GravBoots(string name, int dex) : base(name)
        {
            DexterityBonus = dex;
            Desc = $"This increases a character's dexterity by {dex}.";
        }

        public void Equip(Hero target)
        {
            target.Dexterity += DexterityBonus;
        }
    }
}