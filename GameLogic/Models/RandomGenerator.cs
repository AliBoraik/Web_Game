using System;
using System.Diagnostics.CodeAnalysis;

namespace GameLogic.Models
{
    public static class RandomGenerator
    {
        private static readonly Random _random = new Random();
        
        
        public static int GetRandomRound(string Damage)
        {
            var a = Convert.ToInt32(Damage.Split("d")[0]);
            var b = Convert.ToInt32(Damage.Split("d")[1]);
            int result = 0;
            for (int i = 0; i < a; i++)
            {
                result += _random.Next(a,b);
            }

            return result;
        }
    }
}