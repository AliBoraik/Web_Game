using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GameLogic.Services
{
    public class GameServices : IGameServices
    {
        private readonly Random _random = new();
        public int GetRandomRound(string damage)
        {
            var a = Convert.ToInt32(damage.Split("d")[0]);
            var b = Convert.ToInt32(damage.Split("d")[1]);
            int result = 1;
            for (int i = 0; i < a; i++)
            {
                result += _random.Next(a-1,b+1);
            }

            return result;
        }
    }
}