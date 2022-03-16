using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Game.Models.GameModels;
using Game.Models;
using JsonContent = Game.Models.JsonContent;

namespace Game.Services
{
    public class GameServices : IGameServices
    {
        private readonly HttpClient _client;
        private Monster _monster;
        private HttpResponseMessage _response;

        public GameServices()
        {
            _client = new HttpClient();
        }

        public void CalculationAutomatic(Character character)
        {
            // set min Ac 
            character.MinAc = character.Ac / 2;
            // set Damage per Round
            character.DamagePerRound = new DamagePerRound
            {
                From = character.AttackModifier + 1,
                Max = character.Ac + 1
            };
        }


        public async Task<Monster> GetRandomMonsterFromDb(Character character)
        {
            _response = await _client.PostAsync(Urls.UrlGameDbGetMonster, new JsonContent(character));

            if (_response.IsSuccessStatusCode)
            {
                _monster = await _response.Content.ReadFromJsonAsync<Monster>();

                return _monster;
            }

            return null;
        }
    }
}