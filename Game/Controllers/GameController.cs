using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Game.Models;
using Game.Models.GameModels;
using Game.Services;
using GameLogic.Models;
using Microsoft.AspNetCore.Mvc;
using JsonContent = Game.Models.JsonContent;

namespace Game.Controllers
{
    public class GameController : Controller
    {
        private readonly HttpClient _client;
        private readonly IGameServices _gameServices;
        private HttpResponseMessage _response;
        private ModelGame _modelGame;

        public GameController(IGameServices gameServices)
        {
            _client = new HttpClient();
            _gameServices = gameServices;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Start(Character character)
        {
            if (!ModelState.IsValid) return View("Index", character);

            _response = await _client.PostAsync(Urls.UrlGameDbGetMonster, new JsonContent(character));

            if (_response.IsSuccessStatusCode)
            {
                _gameServices.CalculationAutomatic(character);
                
                _modelGame = new ModelGame
                {
                    Character = character,
                    // get Monster from db
                    Monster = await _response.Content.ReadFromJsonAsync<Monster>()
                };
                
                // Battle game
                
                _response = await _client.PostAsync(Urls.UrlBusinessBattle, new JsonContent(_modelGame));

                var t =  await _response.Content.ReadFromJsonAsync<List<Result>>();
                
                return View(t);
            }

            return BadRequest("Not found the Monster");
        }
    }
}