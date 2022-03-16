using System.ComponentModel.DataAnnotations;

namespace Game.Models.GameModels
{
    public class Character
    {
        [Required]
        [Display(Name = "Student Name")]

        public string Name { get; set; }
        
        [Display(Name = "Hit Points")]
        public int HitPoints { get; set; }
        
        [Display(Name = "Attack Modifier")]
        public int AttackModifier { get; set; }
        
        [Display(Name = "Damage Modifier")]
        public int DamageModifier { get; set; }
        
        [Display(Name = "Weapon")] 
        public int Weapon { get; set; }
        [DamageCheck]
        public string Damage { get; set; }


        [Display(Name = "AC")]
        public int Ac { get; set; }
        
        [Display(Name = "Attack Per Round")]
        public int AttackPerRound { get; set; }
        public int MinAc { get; set; }
        public DamagePerRound DamagePerRound { get; set; }
    }
}