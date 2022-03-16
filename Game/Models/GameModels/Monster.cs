using System.ComponentModel.DataAnnotations;

namespace Game.Models.GameModels
{
    public class Monster
    {
        [Required] [Key] public int Id { get; set; }
        public string Name { get; set; }
        public int Hits { get; set; }
        public int AttackModifier { get; set; }
        public int DamageModifier { get; set; }
        public string Damage { get; set; }
        public int Ac { get; set; }
        public int AttackPerRound { get; set; }
        
    }
}