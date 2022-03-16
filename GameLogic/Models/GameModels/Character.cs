using System.ComponentModel.DataAnnotations;
using GameLogic.Models.GameModels;

namespace GameLogic.Models.GameModels
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
        
        public string Damage { get; set; }

        public DMag DMag { get; set; }


        [Display(Name = "AC")]
        public int Ac { get; set; }
        
        [Display(Name = "Attack Per Round")]
        public int AttackPerRound { get; set; }
        public int MinAc { get; set; }
        public DamagePerRound DamagePerRound { get; set; }
    }
}