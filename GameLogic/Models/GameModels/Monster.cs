using System.ComponentModel.DataAnnotations;

namespace GameLogic.Models.GameModels
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
        public int MinAc { get; set; }
        public int AttackPerRound { get; set; }
        
        public DMag DMag { get; set; }
        
    }
}