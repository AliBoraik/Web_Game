using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Game.Utility
{
    public static class Helper
    {
        public static string AttackM = "Attack Modifier";
        public static string AttackA = "Attack Per Round";
        public static string Damage = "Damage";
        public static string Weapon = "Weapon";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new() { Value = AttackA, Text = AttackA },
                new() { Value = AttackM, Text = AttackM },
                new() { Value = Damage, Text = Damage },
                new() { Value = Weapon, Text = Weapon }
            };
        }
    }
}