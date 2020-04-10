using NinjasInSpace.Interfaces;

namespace NinjasInSpace.Models
{
    public class AlienText : Equipment, IEquipable
    {
        public int IntelligenceBonus;

        public AlienText(string name, int intel) : base(name)
        {
            IntelligenceBonus = intel;
            Desc = $"This increases a character's intelligence by {intel}.";
        }

        public void Equip(Hero target)
        {
            target.Intelligence += IntelligenceBonus;
        }
    }
}