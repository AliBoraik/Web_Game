using System.Linq;
using System.Threading.Tasks;
using Game.Models.GameModels;
using GameDataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameDataBase.Controllers
{
    public class ApiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
        {
            // var m1 = new Monster
            // {
            //     Name = "Ледяная жаба",
            //     Hits = 32,
            //     AttackModifier = 3,
            //     DamageModifier = 1,
            //     Damage = "1d8",
            //     Ac = 12,
            //     AttackPerRound = 1
            // };
            // _db.Monsters.Add(m1);
            // var m2 = new Monster
            // {
            //     Name = "Ааракокра",
            //     Hits = 13,
            //     AttackModifier = 4,
            //     DamageModifier = 2,
            //     Damage = "1d4",
            //     Ac = 12,
            //     AttackPerRound = 1
            // };
            // _db.Monsters.Add(m2);
            // var m3 = new Monster
            // {
            //     Name = "Аббат",
            //     Hits = 136,
            //     AttackModifier = 8,
            //     DamageModifier = 4,
            //     Damage = "1d6",
            //     Ac = 17,
            //     AttackPerRound = 1
            // };
            // _db.Monsters.Add(m3);
            // _db.SaveChanges();
            return View();
        }

        [HttpPost]
        public IActionResult GetMonster([FromBody] Character character)
        {
            var monster = _db.Monsters
                .AsQueryable()
                .RandomElement(c=> true);

            if (monster != null) return Ok(monster);
            return NotFound("There are no monsters available");
        }

        [HttpPost]
        public async Task<IActionResult> Save(Monster monster)
        {
            if (monster != null)
            {
                await _db.Monsters.AddAsync(monster);
                await _db.SaveChangesAsync();
                return RedirectToAction("Monster");
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Monster result)
        {
            _db.Monsters.Remove(result);
            await _db.SaveChangesAsync();
            return Ok();
        }

        public IActionResult Monster()
        {
            return View(_db.Monsters.ToList());
        }

        public IActionResult AddMonster()
        {
            return View();
        }
    }
}